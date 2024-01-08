using Adesso.WorldLeague.Leagues;
using Microsoft.Extensions.DependencyInjection;

namespace Adesso.WorldLeague
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static void AddApplicationsServices(this IServiceCollection sc) 
        {
            sc.AddEfCoreServices();
            sc.AddTransient<ILeagueAppService,LeagueAppService>();
        }
    }
}
