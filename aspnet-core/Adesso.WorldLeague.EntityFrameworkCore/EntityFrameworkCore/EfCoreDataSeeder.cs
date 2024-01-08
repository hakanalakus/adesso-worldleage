using Adesso.WorldLeague.Countries;
using System;
using System.Threading.Tasks;

namespace Adesso.WorldLeague.EntityFrameworkCore
{
    public class EfCoreDataSeeder
    {
        private readonly WorldLeagueDbContext _dbContext;
        public EfCoreDataSeeder(WorldLeagueDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SeedAsync()
        {
            await _dbContext.Database.EnsureCreatedAsync();
            await AddCountriesAsync();
            await _dbContext.SaveChangesAsync();

            await _dbContext.DisposeAsync();
        }

        private async Task AddCountriesAsync()
        {
            var tr = new Country { Id = Guid.NewGuid(), Code = "TR", Name = "Türkiye" };
            tr.AddTeam("Adesso Istanbul");
            tr.AddTeam("Adesso Ankara");
            tr.AddTeam("Adesso Izmir");
            tr.AddTeam("Adesso Antalya");

            var de = new Country { Id = Guid.NewGuid(), Code = "DE", Name = "Almanya" };
            de.AddTeam("Adesso Berlin");
            de.AddTeam("Adesso Frankfurt");
            de.AddTeam("Adesso Münih");
            de.AddTeam("Adesso Dortmund");

            var fr = new Country { Id = Guid.NewGuid(), Code = "FR", Name = "Fransa" };
            fr.AddTeam("Adesso Paris");
            fr.AddTeam("Adesso Marsilya");
            fr.AddTeam("Adesso Nice");
            fr.AddTeam("Adesso Lyon");

            var hl = new Country { Id = Guid.NewGuid(), Code = "HL", Name = "Hollanda" };
            hl.AddTeam("Adesso Amsterdam");
            hl.AddTeam("Adesso Rotterdam");
            hl.AddTeam("Adesso Lahey");
            hl.AddTeam("Adesso Eindhoven");

            var pt = new Country { Id = Guid.NewGuid(), Code = "PT", Name = "Portekiz" };
            pt.AddTeam("Adesso Lisbon");
            pt.AddTeam("Adesso Porto");
            pt.AddTeam("Adesso Braga");
            pt.AddTeam("Adesso Coimbra");

            var it = new Country { Id = Guid.NewGuid(), Code = "IT", Name = "İtalya" };
            it.AddTeam("Adesso Roma");
            it.AddTeam("Adesso Milano");
            it.AddTeam("Adesso Venedik");
            it.AddTeam("Adesso Napoli");

            var sp = new Country { Id = Guid.NewGuid(), Code = "SP", Name = "İspanya" };
            sp.AddTeam("Adesso Sevilla");
            sp.AddTeam("Adesso Madrid");
            sp.AddTeam("Adesso Barselona");
            sp.AddTeam("Adesso Granada");

            var bg = new Country { Id = Guid.NewGuid(), Code = "BG", Name = "Belçika" };
            bg.AddTeam("Adesso Brüksel");
            bg.AddTeam("Adesso Brugge");
            bg.AddTeam("Adesso Gent");
            bg.AddTeam("Adesso Anvers");

            await _dbContext.Countries.AddRangeAsync(tr, de, fr, hl, pt, it, sp, bg);
        }
    }
}
