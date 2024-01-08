using Adesso.WorldLeague.Groups;
using System.Collections.Generic;

namespace Adesso.WorldLeague.Leagues
{
    public class CreateLeagueOutput
    {
        public List<GroupDto> Groups { get; set; }

        public CreateLeagueOutput()
        {
           Groups = new List<GroupDto>();
        }
    }
}
