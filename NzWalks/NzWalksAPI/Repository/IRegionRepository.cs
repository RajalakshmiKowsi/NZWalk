using NzWalksAPI.Models.Domain;

namespace NzWalksAPI.Repository
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllAsych();
        Task<Region> GetByIdAsych(Guid Id);
        Task<Region> AddRegionAsych(Region region);

        Task<Region> DeleteRegionAsych(Guid Id);
        Task<Region> UpdateRegionAsych(Guid Id,Region region);
    }
}
