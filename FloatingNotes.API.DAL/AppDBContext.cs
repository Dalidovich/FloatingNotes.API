using System.Reflection;
using FloatingNotes.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FloatingNotes.API.DAL
{
    public class AppDBContext : DbContext
    {
        public DbSet<FloatingNote> FloatingNotes { get; set; }
        public DbSet<ConnectionFloatingNote> ConnectionFloatingNotes { get; set; }

        public void UpdateDatabase()
        {
            Database.EnsureDeleted();
            Database.Migrate();
        }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public AppDBContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
