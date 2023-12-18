using AdessoWL.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdessoWL.Application.Interfaces.Repositories;

public interface ITeamRepository
{
    public Task<List<TeamEntity>> GetTeamsWithCountries();
}
