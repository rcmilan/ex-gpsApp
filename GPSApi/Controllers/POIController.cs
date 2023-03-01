using GPSApi.Database.Interfaces;
using GPSApi.Domain.Entities;
using GPSApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

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

            var pointsInRadius = await repository.GetInRadius(poi.PointX, poi.PointY);

            return Ok(pointsInRadius);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostPointOfInterestRequest request)
        {
            var poi = new PointOfInterest
            {
                Name = request.Name,
                PointX = (uint)request.X,
                PointY = (uint)request.Y
            };

            await repository.Add(poi);

            var response = new PostPointOfInterestResponse(poi.Id, poi.Name, (int)poi.PointX, (int)poi.PointY);

            return Ok(response);
        }
    }
}