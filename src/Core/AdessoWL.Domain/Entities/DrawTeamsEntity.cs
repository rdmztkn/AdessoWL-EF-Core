using AdessoWL.Domain.Common;

namespace AdessoWL.Domain.Entities;

public class DrawTeamsEntity : BaseEntity
{
    public int TeamId { get; set; }
    public int GroupId { get; set; }

    public virtual DrawGroupsEntity DrawGroupsEntity { get; set; }
    public virtual TeamEntity TeamEntity { get; set; }
}
