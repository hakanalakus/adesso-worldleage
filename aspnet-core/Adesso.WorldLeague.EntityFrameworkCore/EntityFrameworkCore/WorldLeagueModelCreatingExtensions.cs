using Adesso.WorldLeague.Countries;
using Adesso.WorldLeague.Groups;
using Adesso.WorldLeague.Leagues;
using Adesso.WorldLeague.Teams;
using Microsoft.EntityFrameworkCore;

namespace Adesso.WorldLeague.EntityFrameworkCore
{
    public static class WorldLeagueModelCreatingExtensions
    {
        public static void ConfigureWorldLeague(this ModelBuilder builder) 
        {

            builder.Entity<League>(b =>
            {
                b.HasKey(p => p.Id);
                b.Property(p => p.CreatorName).IsRequired().HasMaxLength(LeagueConsts.MaxNameLength);
            });

            builder.Entity<Group>(b =>
            {
                b.HasKey(p => p.Id);
                b.Property(p => p.GroupName).HasMaxLength(GroupConsts.MaxNameLength).IsRequired();

                b.HasOne<League>().WithMany(p => p.Groups).HasForeignKey(x => x.LeagueId).OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<GroupTeam>(b =>
            {
                b.HasKey(p => new { p.GroupId,p.TeamId });
                b.HasOne<Group>(p => p.Group).WithMany(p => p.GroupTeams).HasForeignKey(x => x.GroupId);
                b.HasOne<Team>(p => p.Team).WithMany(p => p.TeamGroups).HasForeignKey(x => x.TeamId);
            });


            builder.Entity<Country>(b =>
            {
                b.HasKey(p => p.Id);
                b.Property(p => p.Name).HasMaxLength(CountryConsts.MaxNameLength).IsRequired();
                b.Property(p => p.Code).HasMaxLength(CountryConsts.MaxCodeLength).IsRequired();
            });

            builder.Entity<Team>(b =>
            {
                b.HasKey(p => p.Id);
                b.Property(p => p.Name).HasMaxLength(TeamConsts.MaxNameLength).IsRequired();
                b.HasOne<Country>().WithMany(p => p.Teams).HasForeignKey(x => x.CountryId);
            });

        }

    }
}
