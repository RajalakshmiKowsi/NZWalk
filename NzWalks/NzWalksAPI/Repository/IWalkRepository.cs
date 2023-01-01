using NzWalksAPI.Models.Domain;

namespace NzWalksAPI.Repository
{
    public interface IWalkRepository
    {
        Task<IEnumerable<Walk>> GetAllAsync();
        Task<Walk> GetWalkByIdAsync(Guid id);
        Task<Walk> AddWalkAsync(Walk walk);

        Task<Walk> DeleteRegionAsych(Guid Id);
        Task<Walk> UpdateRegionAsych(Guid Id, Walk region);
    }
}
