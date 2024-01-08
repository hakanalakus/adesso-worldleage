using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace Adesso.WorldLeague.Leagues
{
    public static class LeagueEndpointsExtension
    {
        private const string UrlPrefix = "/api/league";

        public static void MapLeagueServiceEndpoints(this WebApplication app) 
        {
            app.MapPost(UrlPrefix, async (ILeagueAppService leagueService, [FromBody] CreateLeagueInput input) => {

                var output = await leagueService.CreateAsync(input);
                return output;
            });
        }
    }
}
