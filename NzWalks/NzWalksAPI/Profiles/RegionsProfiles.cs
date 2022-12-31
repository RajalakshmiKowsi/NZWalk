using AutoMapper;
namespace NzWalksAPI.Profiles
{
    public class RegionsProfiles:Profile
    {
        public RegionsProfiles()
        {
            CreateMap<Models.Domain.Region, Dto.Region>().ReverseMap(); 
        }
    }
}
