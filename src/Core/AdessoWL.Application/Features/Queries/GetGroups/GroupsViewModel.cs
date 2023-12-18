using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace AdessoWL.Application.Features.Queries.GetGroups;

public class GroupsViewModel
{
    public List<GroupViewModel> Groups { get; set; } = new();
}

public class GroupViewModel
{
    public string GroupName { get; set; }
    public List<TeamViewModel> Teams { get; set; }

    public GroupViewModel()
    {
        Teams = new();
    }

    public override string ToString()
    {
        return $"{GroupName} - {string.Join(',', Teams.Select(i => i.Name))}";
    }
}

public class TeamViewModel
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Name { get; set; }
}