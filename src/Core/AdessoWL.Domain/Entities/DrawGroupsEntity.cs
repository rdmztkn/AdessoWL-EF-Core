using AdessoWL.Domain.Common;
using System.Collections.Generic;

namespace AdessoWL.Domain.Entities;

public class DrawGroupsEntity : BaseEntity
{
    public string GroupName { get; set; }

    public int DrawId { get; set; }

    public virtual DrawEntity DrawEntity { get; set; }

    public virtual ICollection<DrawTeamsEntity> DrawTeams { get; set; }
}
