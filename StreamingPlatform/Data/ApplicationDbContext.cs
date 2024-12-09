using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StreamingPlatform.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Artist> Artist { get; set; } = default!;
        public DbSet<Genre> Genre { get; set; } = default!;
        public DbSet<MusicVideo> MusicVideo { get; set; } = default!;
        public DbSet<Song> Song { get; set; } = default!;
    }
}
