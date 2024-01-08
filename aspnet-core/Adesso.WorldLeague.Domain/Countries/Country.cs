using Adesso.WorldLeague.BaseEntities;
using Adesso.WorldLeague.Teams;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Adesso.WorldLeague.Countries
{
    public class Country:Entity
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ICollection<Team> Teams { get; private set; }


        public Country()
        {
            Teams = new Collection<Team>();
        }

        public void AddTeam(string name) 
        {
            Teams.Add(new Team { CountryId = Id,Name = name });    
        }

    }
}
