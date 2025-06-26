using DriverFareCalcAPI.DTO;
using DriverFareCalcAPI.IServices;
using DriverFareCalcAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DriverFareCalcAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FareController : ControllerBase
    {
        private readonly IFareCalculator _fareCalculator;

        public FareController(IFareCalculator fareCalculator)
        {
            _fareCalculator = fareCalculator;
        }

        /// <summary>
        /// Calculates fare based on distance.
        /// </summary>
        /// <param name="request">A request containing distance in miles</param>
        /// <returns>Total fare in GBP</returns>
        /// <response code="200">Returns the total fare</response>
        /// <response code="400">If the input is invalid</response>
        [HttpPost("calculate")]
        public ActionResult CalculateFare([FromBody] FareRequest request)
        {
            if (request == null || request.Distance < 0)
                return BadRequest("Invalid distance input.");

            double fare = _fareCalculator.CalculateFare(request.Distance);
            return Ok(new { fare });
        }
    }
}

