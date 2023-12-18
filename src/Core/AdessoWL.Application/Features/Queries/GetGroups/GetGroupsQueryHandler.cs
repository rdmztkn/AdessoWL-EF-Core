using AdessoWL.Application.Helpers;
using AdessoWL.Application.Interfaces.Repositories;
using AdessoWL.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AdessoWL.Application.Features.Queries.GetGroups;

public class GetGroupsQueryHandler(ITeamRepository teamRepository,
                                   IDrawRepository drawRepository,
                                   IMapper mapper) : IRequestHandler<GetGroupsQuery, GroupsViewModel>
{
    private static CountryEntity GetRandomCountry(IEnumerable<CountryEntity> countries,
                                                  HashSet<int> exceptIds)
    {
        var foundCountry = countries
                                .Where(i => i.Teams.Count > 0)
                                .Where(i => !exceptIds.Contains(i.Id))
                                .MaxBy(i => i.Teams.Count);

        return foundCountry;
    }

    public async Task<GroupsViewModel> Handle(GetGroupsQuery request, CancellationToken cancellationToken)
    {
        var result = new GroupsViewModel();

        var teams = await teamRepository.GetTeamsWithCountries();
        var countries = teams.Select(i => i.Country).Distinct().ToList();

        int teamCountInGroup = teams.Count / request.GroupNumber;

        var groups = GroupHelper.GenerateGroups(request.GroupNumber);

        var countryHashSet = new HashSet<int>();

        foreach (var group in groups)
        {
            var groupViewModel = new GroupViewModel { GroupName = group.GroupName };

            for (int i = 0; i < teamCountInGroup; i++)
            {
                // Get country
                var foundCountry = GetRandomCountry(countries, countryHashSet);
                countryHashSet.Add(foundCountry.Id);

                // Get Team of the country
                var teamIndex = Random.Shared.Next(foundCountry.Teams.Count);
                var foundTeam = foundCountry.Teams.ElementAt(teamIndex);
                foundCountry.Teams.Remove(foundTeam); // make sure team cannot be selected again

                // make sure country is not empty
                if (foundCountry.Teams.Count == 0)
                {
                    countries.Remove(foundCountry);
                }

                var teamViewModel = mapper.Map<TeamViewModel>(foundTeam);
                groupViewModel.Teams.Add(teamViewModel);
            }

            countryHashSet.Clear();

            result.Groups.Add(groupViewModel);
        }

        var drawEntity = new DrawEntity
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            CreatedDate = DateTime.Now,
            DrawGroups = new List<DrawGroupsEntity>()
        };

        foreach (var group in result.Groups)
        {
            var groupEntity = new DrawGroupsEntity
            {
                GroupName = group.GroupName,
                DrawTeams = new List<DrawTeamsEntity>()
            };

            drawEntity.DrawGroups.Add(groupEntity);

            groupEntity.DrawTeams = new List<DrawTeamsEntity>();

            foreach (var team in group.Teams)
            {
                var drawTeamsEntity = new DrawTeamsEntity
                {
                    TeamId = team.Id,
                    GroupId = groupEntity.Id
                };

                groupEntity.DrawTeams.Add(drawTeamsEntity);
            }
        }

        await drawRepository.CreateDraw(drawEntity);

        return result;

    }
}
