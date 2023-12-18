using MediatR;

namespace AdessoWL.Application.Features.Queries.GetGroups;

public class GetGroupsQuery : IRequest<GroupsViewModel>
{
    public GetGroupsQuery(int groupNumber, string firstName, string lastName)
    {
        GroupNumber = groupNumber;
        FirstName = firstName;
        LastName = lastName;
    }

    public int GroupNumber { get; set; } // 4 or 8

    public string FirstName { get; set; }
    public string LastName { get; set; }


}
