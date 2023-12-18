using AdessoWL.Domain.Common;
using System.Collections.Generic;

namespace AdessoWL.Domain.Entities
{
    public class TeamEntity : BaseEntity
    {
        public string Name { get; set; }

        public int CountryId { get; set; }

        public virtual CountryEntity Country { get; set; }

        public virtual ICollection<DrawTeamsEntity> DrawTeams { get; set; }
    }
}
