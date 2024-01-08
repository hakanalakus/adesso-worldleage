using Adesso.WorldLeague.Base;
using Adesso.WorldLeague.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Adesso.WorldLeague
{
    public static class EfCoreServiceCollectionExtension
    {
        public static void AddEfCoreServices(this IServiceCollection sc)
        {

            sc.AddDbContext<WorldLeagueDbContext>(opt =>
            {
                opt.UseInMemoryDatabase("WorldLeagueContext");
            });

            sc.AddTransient(typeof(IRepository<>), typeof(EfCoreRepository<>));
            sc.AddTransient<EfCoreDataSeeder>();
        }
    }
}
