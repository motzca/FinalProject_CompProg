using Microsoft.EntityFrameworkCore;

namespace FinalProject_CompProg.Data
{
    public class StudentsContext : DbContext

    {
         public StudentsContext(DbContextOptions<StudentsContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<Student>().HasData(
                new Student { id = 1, fullName = "Chloe Motz", birthdate = "04/18/2001", collegeProgram = "Software Application", collegeYear = "Junior"}
            );
        }
         public DbSet<Student> StudentInfo {get; set;}
    }
}