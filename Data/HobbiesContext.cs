using Microsoft.EntityFrameworkCore;
using FinalProject_CompProg.Models;

namespace FinalProject_CompProg.Data
{
    public class HobbiesContext : DbContext

    {
        public HobbiesContext(DbContextOptions<HobbiesContext> options) : base(options) {}
        
        public DbSet<Hobbies> Hobbies { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Hobbies>().HasData(
                new Hobbies {id = 0, name = "Designing", activityType = "Active", mainInterest = "Graphical", avgTimeSpent = 4},
                new Hobbies {id = 1, name = "Reading", activityType = "Passive", mainInterest = "Thrillers", avgTimeSpent = 7},
                new Hobbies {id = 2, name = "Club Sports", activityType = "Active", mainInterest = "Soccer/Table Tennis", avgTimeSpent = 2});
        }

         public DbSet<Hobbies> Hobby {get; set;}
    }
}
