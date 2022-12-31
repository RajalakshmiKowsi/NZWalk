using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NzWalksAPI.Models.Domain;
using NzWalksAPI.Repository;

namespace NzWalksAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository,IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllRegion()
        {
            var regions = regionRepository.GetAll();

            //var regionsDto = new List<Dto.Region>();
            //regions.ToList().ForEach(region => 
            //{
            //    var regionDto = new Dto.Region()
            //    {
            //        Id = region.Id,
            //        Code = region.Code,
            //        Name = region.Name,
            //        Area = region.Area,
            //        Lat = region.Lat,
            //        Long = region.Long,
            //        Population = region.Population


            //    };
            //    regionsDto.Add(regionDto);
            //}
            //);
            mapper.Map<List<Dto.Region>>(regions);
            return Ok(regions);
        }
    }
}
