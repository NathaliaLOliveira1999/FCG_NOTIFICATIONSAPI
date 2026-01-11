using Microsoft.EntityFrameworkCore;

namespace FCG_NOTIFICATIONSAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //public DbSet<Game> Games { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Game>().HasKey(g => g.IdGames);

            base.OnModelCreating(modelBuilder);
        }
    }
}