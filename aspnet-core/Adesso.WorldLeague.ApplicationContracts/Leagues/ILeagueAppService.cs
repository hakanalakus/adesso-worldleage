using System.Threading.Tasks;

namespace Adesso.WorldLeague.Leagues
{
    public interface ILeagueAppService
    {
        Task<CreateLeagueOutput> CreateAsync(CreateLeagueInput input);
    }
}
