using Microsoft.EntityFrameworkCore;

namespace Mission06_Erickson.Models
{
    public class MovieCollectionContext : DbContext
    {
        public MovieCollectionContext(DbContextOptions<MovieCollectionContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie { MovieId = 1, Category = "Fantasy", Title = "Hercules", Year = 1997, Director = "John Musker", Rating = "PG" },
                new Movie { MovieId = 2, Category = "Action", Title = "National Treasure", Year = 2004, Director = "Jon Turteltaub", Rating = "PG" },
                new Movie { MovieId = 3, Category = "Action", Title = "Uncharted", Year = 2022, Director = "Ruben Fleischer", Rating = "PG-13" }
            );
        }
    }
}