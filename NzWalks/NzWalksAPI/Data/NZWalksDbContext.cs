using Microsoft.EntityFrameworkCore;
using NzWalksAPI.Models.Domain;

namespace NzWalksAPI.Data
{
    public class NZWalksDbContext: DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> options):base(options)
        {

        }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<WalkDifficult> WalkDifficult { get; set; }
    }
}
