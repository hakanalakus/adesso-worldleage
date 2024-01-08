using System.Collections.Generic;

namespace Adesso.WorldLeague.Groups
{
    public class GroupDto
    {
        public string GroupName { get; set; }
        public List<TeamDto> Teams { get; set; }

        public GroupDto()
        {
        }
    }
}
