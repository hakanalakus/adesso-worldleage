using Adesso.WorldLeague.Base;
using Adesso.WorldLeague.Exceptions;
using Adesso.WorldLeague.Groups;
using Adesso.WorldLeague.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adesso.WorldLeague.Leagues
{
    public class LeagueAppService : ILeagueAppService
    {

        private readonly IRepository<League> _leagueRepository;
        private readonly IRepository<Team> _teamRepository;
        public LeagueAppService(IRepository<League> leagueRepository, IRepository<Team> teamRepository)
        {
            _leagueRepository = leagueRepository;
            _teamRepository = teamRepository;
        }

        public async Task<CreateLeagueOutput> CreateAsync(CreateLeagueInput input)
        {
            CheckGroupCount(input);
            var output = new CreateLeagueOutput();
            var teams = await _teamRepository.GetAllAsync();
            teams = ShuffleTeams(teams);

            var league = new League()
            {
                Id = Guid.NewGuid(),
                CreatorName = input.CreatorName,
                CreatorSurname =
                input.CreatorSurname
            };

            var selectedTeamIds = new List<Guid>();
            var teamCount = teams.Count / input.GroupCount;

            for (int i = 0; i < input.GroupCount; i++)
            {
                var groupTeams = teams.Skip(i * teamCount).Take(teamCount);
                var group = new Group()
                {
                    Id = Guid.NewGuid(),
                    GroupName = GroupKeys[i],
                    LeagueId = league.Id
                };

                foreach (var t in groupTeams)
                {
                    group.AddTeam(t.Id);
                }

                output.Groups.Add(new GroupDto
                {
                    GroupName = group.GroupName,
                    Teams = groupTeams.Select(x => new TeamDto { Name = x.Name }).ToList()
                });

                league.Groups.Add(group);
            }

            await _leagueRepository.InsertAsync(league);
            return output;

        }

        private void CheckGroupCount(CreateLeagueInput input) 
        {
            if (input.GroupCount == 8 || input.GroupCount == 4)
                return;

            throw new UserFriendlyException("Invalid group count.Group count should be 4 or 8.");
        }

        private List<Team> ShuffleTeams(List<Team> teams)
        {
            teams = teams.OrderBy(x => Random.Shared.Next()).ToList(); //Shuffle
            var groupedTeams = teams.GroupBy(x => x.CountryId).ToList();
            var result = new List<Team>();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var g = groupedTeams[j].ToArray()[i];
                    result.Add(g);
                }
            }

            return result;
        }

        private static string[] GroupKeys = { "A", "B", "C", "D", "E", "F", "G", "H" };
    }
}
