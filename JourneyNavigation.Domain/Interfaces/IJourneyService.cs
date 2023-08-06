using JourneyNavigation.Domain.Dtos;

namespace JourneyNavigation.Domain.Interfaces
{
    public interface IJourneyService
    {
        Task<JourneyDto> AddJourney(JourneyDto journey);
        Task<JourneyDto> DeleteJourney(int journeyId);
        Task<JourneyDto> GetJourneyById(int journeyId);
        Task<List<JourneyDto>> GetAllJourneysByUser(string userId);
        Task<RoutePerMonthDto> MonthlyRouteDisplay(int monthNumber);
        Task<List<JourneyDto>> FilterJourneys(FilterDto filters);
    }
}
