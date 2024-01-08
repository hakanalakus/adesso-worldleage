using Adesso.WorldLeague.BaseEntities;
using Adesso.WorldLeague.Groups;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Adesso.WorldLeague.Teams
{
    public class Team:Entity,ISoftDelete
    {
        public Guid CountryId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get ; set; }

        public virtual ICollection<GroupTeam> TeamGroups { get; private set; }

        public Team()
        {
            TeamGroups = new Collection<GroupTeam>();
        }
    }
}
