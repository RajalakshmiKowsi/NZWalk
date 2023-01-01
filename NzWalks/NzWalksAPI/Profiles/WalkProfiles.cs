using AutoMapper;

namespace NzWalksAPI.Profiles
{
    public class WalkProfiles:Profile
    {
        public WalkProfiles()
        {
            CreateMap<Models.Domain.Walk, Dto.Walk>().ReverseMap();
            CreateMap<Models.Domain.WalkDifficult, Dto.WalkDifficult>().ReverseMap();
        }
    }
}
