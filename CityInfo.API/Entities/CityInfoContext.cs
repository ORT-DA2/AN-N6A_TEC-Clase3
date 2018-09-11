
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.Entities
{
    public class CityInfoContext : DbContext
    {
        /*public CityInfoContext()
        {
            Database.Migrate();
        }*/
        public DbSet<City> Cities { get; set; }

        public DbSet<PointOfInterest> PointsOfInterest { get; set; }

        public DbSet<CityImage> CityImages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // localdb comes with VS2017, chage it for you own sql instance by replacing the conn string
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CityInfo;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // https://docs.microsoft.com/en-us/ef/core/modeling/relationships#fluent-api
            modelBuilder.Entity<City>().Ignore(c => c.PointsOfInterest);

            // If  you are using Fluent Api ,use Configuration classes to keep separation of concerns and an clean context
            modelBuilder.ApplyConfiguration(new PointOfInterestConfiguration());

            //Data Seeding
            //https://docs.microsoft.com/en-us/ef/core/modeling/data-seeding
            modelBuilder.Entity<City>().HasData(new City()
                {
                    Id = 1,
                    Name = "New York City",
                    Description = "Great park in the middle",
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest(){Id = 10,Name = "Point 10", Description = "Welcome to point 10"},
                        new PointOfInterest(){Id = 11,Name = "Point 11", Description = "Welcome to point 11"},
                        new PointOfInterest(){Id = 12,Name = "Point 12", Description = "Welcome to point 12"}
                    }
                },
                new City()
                {
                    Id = 2,
                    Name = "Boston",
                    Description = "the capital city and most populous municipality of the Commonwealth of Massachusetts in the United States.",
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest(){Id = 13,Name = "Point 13", Description = "Welcome to point 13"},
                        new PointOfInterest(){Id = 14,Name = "Point 14", Description = "Welcome to point 14"},
                        new PointOfInterest(){Id = 15,Name = "Point 15", Description = "Welcome to point 15"}
                    }
                },
                new City()
                {
                    Id = 3,
                    Name = "London",
                    Description = "It was founded by the Romans, who named it Londinium",
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest(){Id = 16,Name = "Point 16", Description = "Welcome to point 16"}
                    }
                });
        }
    }
}
