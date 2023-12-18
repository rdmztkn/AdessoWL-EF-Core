using AdessoWL.Domain.Common;
using System;
using System.Collections.Generic;

namespace AdessoWL.Domain.Entities;

public class DrawEntity : BaseEntity
{
    public DateTime CreatedDate { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public virtual ICollection<DrawGroupsEntity> DrawGroups { get; set; }
}
