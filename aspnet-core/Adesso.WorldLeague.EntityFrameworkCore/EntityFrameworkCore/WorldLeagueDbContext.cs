using Adesso.WorldLeague.BaseEntities;
using Adesso.WorldLeague.Countries;
using Adesso.WorldLeague.Groups;
using Adesso.WorldLeague.Leagues;
using Adesso.WorldLeague.Teams;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Adesso.WorldLeague.EntityFrameworkCore
{
    public class WorldLeagueDbContext : DbContext
    {
        public virtual DbSet<League> Leagues { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

        public  virtual DbSet<GroupTeam> GroupTeams { get; set; }


        public WorldLeagueDbContext()
        {
        }

        public WorldLeagueDbContext(DbContextOptions<WorldLeagueDbContext> options) : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries();

            foreach (var entry in entries)
            {
                if (entry.Entity is ISoftDelete softDeleteEntity)
                {
                    if (entry.State == EntityState.Deleted)
                    {
                        softDeleteEntity.IsDeleted = true;
                        softDeleteEntity.DeletionTime = DateTime.Now;
                    }
                }

                if (entry.Entity is ICreationAuditedEntity creationAuditedEntity) 
                {
                    if (entry.State == EntityState.Added) 
                    {
                        creationAuditedEntity.CreationTime = DateTime.Now;
                    }
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
