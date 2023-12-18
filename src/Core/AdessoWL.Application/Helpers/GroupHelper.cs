using AdessoWL.Application.Features.Queries.GetGroups;
using System.Collections.Generic;

namespace AdessoWL.Application.Helpers;

public class GroupHelper
{
    public static List<GroupViewModel> GenerateGroups(int groupNumber)
    {
        var groups = new List<GroupViewModel>();
        var groupNames = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H" };

        for (int i = 0; i < groupNumber; i++)
        {
            var group = new GroupViewModel
            {
                GroupName = groupNames[i]
            };

            groups.Add(group);
        }

        return groups;
    }
}
