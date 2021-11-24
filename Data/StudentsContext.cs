using Microsoft.EntityFrameworkCore;
using FinalProject_CompProg.Models;

namespace FinalProject_CompProg.Data
{
    public class StudentsContext : DbContext

    {
         public StudentsContext(DbContextOptions<StudentsContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<Student>().HasData(
                new Student { id = 1, fullName = "Chloe Motz", birthDate = "04/18/2001", collegeProgram = "IT - Software Application", collegeYear = "Junior"},
                new Student {id = 2, fullName = "Logan Arnett", birthDate = "12/28/2001", collegeProgram = "IT -Game Development", collegeYear = "Sophomore"},
                new Student {id = 3, fullName = "Srishant Burdhan", birthDate = "01/22/2002", collegeProgram = "IT - Software Development and Technologies Track", collegeYear = "Sophomore"}
            );
        }
         public DbSet<Student> Students {get; set;}
    }
}