using Microsoft.EntityFrameworkCore;
using FinalProject_CompProg.Models;

namespace FinalProject_CompProg.Data
{
    public class MusicContext : DbContext
    {
         public MusicContext(DbContextOptions<MusicContext> options) : base(options) {}
        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<Music>().HasData(
                new Music { id = 1, songTitle = "Taunt", artistName = "Lovejoy", musicGenre = "Indie Rock"},
                new Music {id = 2, songTitle = "Tongues & Teeth", artistName = "The Crane Wives", musicGenre = "American Folk Rock"},
                new Music {id = 3, songTitle = "Pretty In Pink", artistName = "Scream Queen", musicGenre = "Screamo"}
            );
        }
         public DbSet<Music> Musicians {get; set;}
    }
}