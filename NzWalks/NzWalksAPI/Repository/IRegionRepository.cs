using NzWalksAPI.Models.Domain;

namespace NzWalksAPI.Repository
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllAsych();
    }
}
