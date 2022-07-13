using Microsoft.EntityFrameworkCore;
using MovieECommerce.Models;

namespace MovieECommerce.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie_Actor>()
                        .HasKey(x => new { x.MovieId, x.ActorId });

            modelBuilder.Entity<Movie_Actor>()
                        .HasOne(m => m.Movie).WithMany(ma => ma.MovieActors)
                        .HasForeignKey(m => m.MovieId);

            modelBuilder.Entity<Movie_Actor>()
                        .HasOne(a => a.Actor).WithMany(ma => ma.MovieActors)
                        .HasForeignKey(m => m.MovieId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Movie_Actor> Movie_Actors { get; set; }
    }
}
