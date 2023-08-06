using JourneyNavigation.Infrastructure.Data;
using JourneyNavigation.Domain.Interfaces;
using JourneyNavigation.Domain.Models;
using JourneyNavigation.Domain.Dtos;

namespace JourneyNavigation.Infrastructure.Repositories
{
    public class JourneyRepository : Repository<Journey>, IJourneyRepository
    {

        private readonly ApplicationDbContext _appContext;

        public JourneyRepository(ApplicationDbContext context) : base(context)
        {
            _appContext = context;
        }

        public bool UserDailyAchievement(JourneyDto journey)
        {
            var disTraveledByUser = GetAllJourneys(journey.JourneyUserId).Where(j => j.StartTime.ToShortDateString() == journey.StartTime.ToShortDateString() && j.StartTime.ToShortDateString() == j.ArrivalTime.ToShortDateString() && j.ArrivalTime.ToShortDateString() == journey.ArrivalTime.ToShortDateString()).Select(j => j.DistanceInKm).ToList().Sum();

            if (disTraveledByUser > 20) return true;
            else return false;
        }

        public List<Journey> GetAllJourneys(string userId)
        {
            return _appContext.Journeys.Where(j => j.JourneyUserId == userId).ToList();
        }

        public RoutePerMonthDto MonthlyRouteDisplay(int monthNumber)
        {
            decimal monthJourneysDistance = _appContext.Journeys.Where(j => j.StartTime.Month == monthNumber && j.ArrivalTime.Month == monthNumber && j.StartTime.Year == DateTime.Now.Year && j.ArrivalTime.Year == DateTime.Now.Year).Select(j => j.DistanceInKm).ToList().Sum();
            
            RoutePerMonthDto route = new RoutePerMonthDto(){
                RouteCompleted = "The total route distance travelled for this month is " + monthJourneysDistance + " km."
            };

            return route;
        }

        public List<Journey> FilterJourneys(FilterDto filters)
        {
            var journeys = _appContext.Journeys.ToList();

            if (filters.UserId != "") journeys = journeys.Where(j => j.JourneyUserId == filters.UserId).ToList();
            if (filters.TransportationTypeId != 0) journeys = journeys.Where(j => j.TransportationTypeId == filters.TransportationTypeId).ToList();
            if (filters.StartDate != null) journeys = journeys.Where(j => j.StartTime >= filters.StartDate).ToList();
            if (filters.ArrivalDate != null) journeys = journeys.Where(j => j.ArrivalTime <= filters.ArrivalDate).ToList();

            if (journeys.Count == 0)
                throw new Exception("Journeys not found");

            return journeys;
        }
    }
}
