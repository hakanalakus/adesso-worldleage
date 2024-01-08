using Adesso.WorldLeague.BaseEntities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Adesso.WorldLeague.Groups
{
    public class Group:Entity
    {
        public Guid LeagueId { get; set; }
        public string GroupName { get; set; }
        public virtual ICollection<GroupTeam> GroupTeams { get; private set; }

        public Group()
        {
            GroupTeams = new Collection<GroupTeam>();
        }

        public void AddTeam(Guid teamId) 
        {
            GroupTeams.Add(new GroupTeam { GroupId = Id,TeamId = teamId });
        }
    }
}

