using Microsoft.EntityFrameworkCore;
using FinalProject_CompProg.Models;

namespace FinalProject_CompProg.Data
{
    public class FinalProjectContext : DbContext
    {
         public FinalProjectContext(DbContextOptions<FinalProjectContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<Student>().HasData(
                new Student { id = 1, fullName = "Chloe Motz", birthDate = "04/18/2001", collegeProgram = "IT - Software Application", collegeYear = "Junior"},
                new Student {id = 2, fullName = "Logan Arnett", birthDate = "12/28/2001", collegeProgram = "IT - Game Development", collegeYear = "Sophomore"},
                new Student {id = 3, fullName = "Srishant Burdhan", birthDate = "01/22/2002", collegeProgram = "IT - Software Development and Technologies Track", collegeYear = "Sophomore"}
            );
              builder.Entity<Restaurant>().HasData(
                new Restaurant {id = 1, name = "McDonalds", foodType = "Burgers", founder = "Richard McDonald and Maurice McDonald", foundingYear = 1955},
                new Restaurant {id = 2, name = "Wendys", foodType = "Burgers", founder = "Dave Thomas", foundingYear = 1969},
                new Restaurant {id = 3, name = "Olive Garden", foodType = "Spaghetti", founder = "Bill Darden", foundingYear = 1982});

            builder.Entity<Music>().HasData(
                new Music { id = 1, songTitle = "Taunt", artistName = "Lovejoy", songYear = "2021", musicGenre = "Indie Rock"},
                new Music {id = 2, songTitle = "Tongues & Teeth", artistName = "The Crane Wives", songYear = "2012", musicGenre = "American Folk Rock"},
                new Music {id = 3, songTitle = "Pretty In Pink", artistName = "Scream Queen", songYear = "2021", musicGenre = "Screamo"}
            );

builder.Entity<Hobbies>().HasData(
                new Hobbies {id = 1, name = "Designing", activityType = "Active", mainInterest = "Graphical", avgTimeSpent = 4},
                new Hobbies {id = 2, name = "Reading", activityType = "Passive", mainInterest = "Thrillers", avgTimeSpent = 7},
                new Hobbies {id = 3, name = "Club Sports", activityType = "Active", mainInterest = "Soccer/Table Tennis", avgTimeSpent = 2});
        }
         public DbSet<Student> Students {get; set;}
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Music> Musicians {get; set;}
        public DbSet<Hobbies> Hobbies { get; set; }

    }
}