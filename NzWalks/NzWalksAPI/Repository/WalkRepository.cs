using Microsoft.EntityFrameworkCore;
using NzWalksAPI.Data;
using NzWalksAPI.Models.Domain;

namespace NzWalksAPI.Repository
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext nZWalksDbContext;

        public WalkRepository(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }
        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await nZWalksDbContext.Walks.Include(x => x.Region)
                 .Include(x => x.WalkDifficult).ToListAsync();
        }



        public async Task<Walk> GetWalkByIdAsync(Guid id)
        {
            return await nZWalksDbContext.Walks.Include(x => x.Region).Include(x => x.WalkDifficult).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk> AddWalkAsync(Walk walk)
        {
            walk.Id = new Guid();
            await nZWalksDbContext.Walks.AddAsync(walk);
            await nZWalksDbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk> DeleteRegionAsych(Guid Id)
        {
            var Walks = await nZWalksDbContext.Walks.FirstOrDefaultAsync(x => x.Id == Id);
             
            if (Walks == null)
            {
                return null;
            }
            //delete the regin
            nZWalksDbContext.Walks.Remove(Walks);
            await nZWalksDbContext.SaveChangesAsync();
            return Walks;
        }

        public async Task<Walk> UpdateRegionAsych(Guid Id, Walk Walk)
        {
            var extingWalk = await nZWalksDbContext.Walks.FirstOrDefaultAsync(x => x.Id == Id);
             
            if (extingWalk == null)
            {
                return null;
            }
            extingWalk.Name = Walk.Name;
            extingWalk.RegionId = Walk.RegionId;
            extingWalk.WalkDifficultId = Walk.WalkDifficultId;
            extingWalk.Length = Walk.Length;
            await nZWalksDbContext.SaveChangesAsync();
            return extingWalk;
        }
    }
}
