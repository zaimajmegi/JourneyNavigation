using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JourneyNavigation.Domain.Dtos;
using JourneyNavigation.Domain.Models;

namespace JourneyNavigation.Domain.Interfaces
{
    public interface IJourneyRepository : IRepository<Journey>
    {
        bool UserDailyAchievement(JourneyDto journey);
        List<Journey> GetAllJourneys(string userId);
        RoutePerMonthDto MonthlyRouteDisplay(int monthNumber);
        List<Journey> FilterJourneys(FilterDto filters);
    }
}
