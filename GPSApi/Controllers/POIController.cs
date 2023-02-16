using GPSApi.Database.Interfaces;
using GPSApi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GPSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class POIController : ControllerBase
    {
        private readonly IPointOfInterestRepository repository;
        public POIController(IPointOfInterestRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("Id")]
        public async Task<IActionResult> Get(Guid Id)
        {
            var poi = await repository.Get(Id);

            var result = new GetPointOfInterestResponse(poi.Id);

            return Ok(result);
        }
    }
}