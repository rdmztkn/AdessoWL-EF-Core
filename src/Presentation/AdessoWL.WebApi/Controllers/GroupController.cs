using AdessoWL.Application.Features.Queries.GetGroups;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdessoWL.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class GroupController : ControllerBase
{
    private readonly IMediator mediator;

    public GroupController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    /// <summary>
    /// Generates the groups with teams
    /// </summary>
    /// <param name="groupNumber">How many groups, either 4 or 8</param>
    /// <param name="firstName">The first name of shuffler</param>
    /// <param name="lastName">The last name of shuffler</param>
    /// <returns>The groups with teams</returns>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<ActionResult<GroupViewModel>> GetGroups(int groupNumber, string firstName, string lastName)
    {
        var query = new GetGroupsQuery(groupNumber, firstName, lastName);
        var validator = new GetGroupsValidator();
        var validationResult = await validator.ValidateAsync(query);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var result = await mediator.Send(query);

        return Ok(result);
    }
}
