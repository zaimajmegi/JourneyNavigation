using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using JourneyNavigation.Domain.Dtos;
using JourneyNavigation.Domain.Interfaces;

namespace JourneyNavigation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class JourneyController : ControllerBase
    {
        private readonly IJourneyService _journeyService;

        public JourneyController(IJourneyService journeyService )
        {
            _journeyService = journeyService;
        }

        [HttpPost(nameof(AddJourney))]
        public async Task<IActionResult> AddJourney([FromBody]JourneyDto journey)
        {
            var result = await _journeyService.AddJourney(journey);
            return Ok(result);
        }

        [HttpDelete(nameof(DeleteJourney))]
        public async Task<IActionResult> DeleteJourney(int journeyId)
        {
            var result = await _journeyService.DeleteJourney(journeyId);
            return Ok(result);
        }

        [HttpGet(nameof(GetJourneyById))]
        public async Task<IActionResult> GetJourneyById(int journeyId)
        {
            var result = await _journeyService.GetJourneyById(journeyId);
            return Ok(result);
        }

        [HttpGet(nameof(GetAllJourneysByUser))]
        public async Task<IActionResult> GetAllJourneysByUser(string userId)
        {
            var result = await  _journeyService.GetAllJourneysByUser(userId);
            return Ok(result);
        }

        [HttpGet(nameof(MonthlyRouteDisplay))]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> MonthlyRouteDisplay(int monthNumber)
        {
            var result = await _journeyService.MonthlyRouteDisplay(monthNumber);
            return Ok(result);
        }

        [HttpGet(nameof(FilterJourneys))]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> FilterJourneys([FromQuery]FilterDto filters)
        {
            var result = await _journeyService.FilterJourneys(filters);
            return Ok(result);
        }
    }
}
