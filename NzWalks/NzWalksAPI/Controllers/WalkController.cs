using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using NzWalksAPI.Repository;

namespace NzWalksAPI.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class WalkController : Controller
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalkController(IWalkRepository walkRepository,IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalksAsync()
        {
            var walkRegion = await walkRepository.GetAllAsync();
            var walkDto = mapper.Map<List<Dto.Walk>>(walkRegion);
            return Ok(walkDto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkByID")]
        public async Task<IActionResult> GetWalkByID(Guid id)
        {
            var walkRegion = await walkRepository.GetWalkByIdAsync(id);

            if(walkRegion== null)
            {
                return NotFound();
            }

            var walkRegionDto = mapper.Map<Dto.Walk>(walkRegion);

            return Ok(walkRegionDto);

        }

        [HttpPost]
        public async Task<IActionResult> AddWalkAsync([FromBody] Dto.AddWalkRequest addWalkRequest)
        {
            var walk = new Models.Domain.Walk
            {
                Length = addWalkRequest.Length,
                Name = addWalkRequest.Name,
                RegionId = addWalkRequest.RegionId,
                WalkDifficultId = addWalkRequest.WalkDifficultId

            };
            var walkDomain = await walkRepository.AddWalkAsync(walk);

            var walkDto = new Dto.Walk
            {
                Id = walkDomain.Id,
                Name = walkDomain.Name,
                RegionId = walkDomain.RegionId,
                WalkDifficultId = walkDomain.WalkDifficultId
            };
            return CreatedAtAction(nameof(GetWalkByID), new { id = walkDto.Id }, walkDto);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            var walk = await walkRepository.DeleteRegionAsych(id);
            if (walk == null)
            {
                return NotFound();
            }
            //
            var regionDto = new Dto.Walk
            {
                Id = walk.Id,
                Length = walk.Length,
                Name = walk.Name,
                RegionId = walk.RegionId,
                WalkDifficultId = walk.WalkDifficultId
            };

            return Ok(regionDto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegionAsych([FromRoute] Guid id, [FromBody] Dto.UpdateWalkRequest updateRegionRequest)
        {
            var updateWalk = new Models.Domain.Walk
            {
               Length = updateRegionRequest.Length,
               Name =updateRegionRequest.Name,
               RegionId =updateRegionRequest.RegionId,
               WalkDifficultId =updateRegionRequest.WalkDifficultId
            };
            var walk = await walkRepository.UpdateRegionAsych(id, updateWalk);

            if (walk == null)
            {
                return NotFound();
            }
            var walkDto = new Dto.Walk
            {
                Length = walk.Length,
                RegionId = walk.RegionId,
                Name = walk.Name,
                WalkDifficultId = walk.WalkDifficultId

            };

            return Ok(walkDto);
        }

    }
}
