using Adesso.WorldLeague.BaseEntities;
using Adesso.WorldLeague.Groups;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Adesso.WorldLeague.Leagues
{
    public class League:CreationAuditedEntity<Guid>
    {
        public string CreatorName { get; set; }
        public string CreatorSurname { get; set; }

        public virtual ICollection<Group> Groups { get; private set; }

        public League()
        {
            Groups = new Collection<Group>();
        }
    }
}
