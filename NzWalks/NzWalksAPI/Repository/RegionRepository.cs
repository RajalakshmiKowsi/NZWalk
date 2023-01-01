using Microsoft.EntityFrameworkCore;
using NzWalksAPI.Data;
using NzWalksAPI.Models.Domain;

namespace NzWalksAPI.Repository
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext nZWalksDbContext;

        public RegionRepository(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }

        public async Task<Region> AddRegionAsych(Region region)
        {
            region.Id = new Guid();
            await nZWalksDbContext.AddRangeAsync(region);
            await nZWalksDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteRegionAsych(Guid Id)
        {
          var region=  await nZWalksDbContext.Regions.FirstAsync(x => x.Id == Id);
            if(region == null)
            {
                return null;
            }
            //delete the regin
            nZWalksDbContext.Regions.Remove(region);
            await nZWalksDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<IEnumerable<Region>> GetAllAsych()
        {
            return await nZWalksDbContext.Regions.ToListAsync();
        }

        public async Task<Region> GetByIdAsych(Guid id)
        {
            return await nZWalksDbContext.Regions.FirstAsync(x => x.Id == id);
        }

        public async Task<Region> UpdateRegionAsych(Guid Id, Region region)
        {
            var extingRegion = await nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == Id);
            if(extingRegion == null)
            {
                return null;
            }
            extingRegion.Code = region.Code;
            extingRegion.Name = region.Name;
            extingRegion.Population = region.Population;
            extingRegion.Area = region.Area;
            extingRegion.Lat = region.Lat;
            extingRegion.Long = region.Long;
            await nZWalksDbContext.SaveChangesAsync();
            return extingRegion;
        }
    }
}
