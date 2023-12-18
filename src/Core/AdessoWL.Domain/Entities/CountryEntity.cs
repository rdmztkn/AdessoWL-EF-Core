using AdessoWL.Domain.Common;
using System.Collections.Generic;

namespace AdessoWL.Domain.Entities;

public class CountryEntity : BaseEntity
{
    public string Name { get; set; }

    public virtual ICollection<TeamEntity> Teams { get; set; }

    //public override int GetHashCode()
    //{
    //    return Id.GetHashCode();
    //}
}
