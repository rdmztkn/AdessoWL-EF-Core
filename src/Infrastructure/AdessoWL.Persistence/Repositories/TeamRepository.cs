using AdessoWL.Application.Interfaces.Repositories;
using AdessoWL.Domain.Entities;
using AdessoWL.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdessoWL.Persistence.Repositories;

public class TeamRepository(AdessoWLContext dbContext) : ITeamRepository
{

    public async Task<List<TeamEntity>> GetTeamsWithCountries()
    {
        var teams = await dbContext
                        .Teams
                        .Include(i => i.Country)
                        //.AsNoTracking()
                        .ToListAsync(); // No filter as we get all teams with countries

        dbContext.ChangeTracker.Clear();

        return teams;
    }
}
