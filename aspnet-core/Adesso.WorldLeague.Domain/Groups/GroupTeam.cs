using Adesso.WorldLeague.BaseEntities;
using Adesso.WorldLeague.Teams;
using System;

namespace Adesso.WorldLeague.Groups
{
    public class GroupTeam:Entity
    {
        public Guid GroupId { get; set; }
        public Guid TeamId { get; set; }

        public virtual Group Group { get; set; }
        public virtual Team Team { get; set; }
    }
}
