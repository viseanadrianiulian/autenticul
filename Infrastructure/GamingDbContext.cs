using Autenticul.Gaming.Domain.Common;
using Autenticul.Gaming.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Autenticul.Gaming.Persistence
{
    public class GamingDbContext : DbContext
    {
        public GamingDbContext(DbContextOptions<GamingDbContext> options)
            : base(options)
        {
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Bet> Bets { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GamingDbContext).Assembly);
            

            //we can seed data
            modelBuilder.Entity<User>().HasData(
                new User 
                { 
                    Id = new Guid("c37e9e97-16ad-4efc-3550-08dd0834301a"),
                    UserName = "admin",
                    Password = BCrypt.Net.BCrypt.HashPassword("pass"),
                    CreatedDate = DateTime.Now, 
                    LastModifiedDate = DateTime.Now 
                });
            //we can seed data
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
