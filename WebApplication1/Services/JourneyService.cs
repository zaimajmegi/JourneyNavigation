using JourneyNavigation.Domain.Dtos;
using JourneyNavigation.Domain.Interfaces;
using JourneyNavigation.Infrastructure;
using JourneyNavigation.API.Extensions;
using JourneyNavigation.Domain.Models;
using System.Threading.Tasks;

namespace JourneyNavigation.API.Services
{
    public class JourneyService : IJourneyService
    {
        private IUnitOfWork _unitOfWork;

        public JourneyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<JourneyDto> AddJourney(JourneyDto journey)
        {
            var taskDb = journey.ToEntity();

            _unitOfWork.Journeys.Add(taskDb);

            await _unitOfWork.SaveChangesAsync();

            if (journey.JourneyUserId != null && journey.StartTime.ToShortDateString() == DateTime.Now.ToShortDateString())
            {
                var user = await _unitOfWork.Users.GetAsync(journey.JourneyUserId);
                if (user == null)
                    throw new Exception("User not found");

                if (_unitOfWork.Journeys.UserDailyAchievement(journey)) user.AchievesDailyGoal = true;
                else user.AchievesDailyGoal = false;

                _unitOfWork.Users.Update(user);
            }

            await _unitOfWork.SaveChangesAsync();

            return journey;
        }

        public async Task<JourneyDto> DeleteJourney(int journeyId)
        {
            var journey = await _unitOfWork.Journeys.GetAsync(journeyId);
            if (journey == null)
                throw new Exception("Journey not found");

            _unitOfWork.Journeys.Remove(journey);
            await _unitOfWork.SaveChangesAsync();

            var journeyDto = JourneyDto.FromEntity(journey);

            if (journeyDto.JourneyUserId != null && journeyDto.StartTime.ToShortDateString() == DateTime.Now.ToShortDateString())
            {
                var user = await _unitOfWork.Users.GetAsync(journeyDto.JourneyUserId);

                if (_unitOfWork.Journeys.UserDailyAchievement(journeyDto)) user.AchievesDailyGoal = true;
                else user.AchievesDailyGoal = false;

                _unitOfWork.Users.Update(user);
                await _unitOfWork.SaveChangesAsync();
            }

            return journeyDto;
        }

        public async Task<JourneyDto> GetJourneyById(int journeyId)
        {
            var journey = await _unitOfWork.Journeys.GetAsync(journeyId);
            if (journey == null)
                throw new Exception("Journey not found");

            var journeyDto = JourneyDto.FromEntity(journey);
            return journeyDto;
        }

        public async Task<List<JourneyDto>> GetAllJourneysByUser(string userId)
        {
            var user = await _unitOfWork.Users.GetAsync(userId);
            if (user == null)
                throw new Exception("User not found");

            var journeys = _unitOfWork.Journeys.GetAllJourneys(userId);
            if (journeys.Count == 0)
                throw new Exception("Journeys not found");

            var journeysDto = JourneyDto.FromEntityList(journeys).OrderByDescending(j => j.DistanceInKm).ToList();
            return journeysDto;
        }

        public async Task<RoutePerMonthDto> MonthlyRouteDisplay(int monthNumber)
        {
            if (monthNumber < 1 || monthNumber > 12)
                throw new Exception("Please enter valid month");

            var route = _unitOfWork.Journeys.MonthlyRouteDisplay(monthNumber);

            return route;
        }

        public async Task<List<JourneyDto>> FilterJourneys(FilterDto filters)
        {
            if (filters.TransportationTypeId != 0)
            {
                var transport = await _unitOfWork.TransportationType.GetAsync(filters.TransportationTypeId);
                if (transport == null)
                    throw new Exception("Transportation type not found");
            }

            if (filters.UserId != "")
            {
                var user = await _unitOfWork.Users.GetAsync(filters.UserId);
                if (user == null)
                    throw new Exception("User not found");
            }

            var journeys = _unitOfWork.Journeys.FilterJourneys(filters);

            var journeysDto = JourneyDto.FromEntityList(journeys).OrderByDescending(j => j.DistanceInKm).ToList();
            return journeysDto;
        }
    }
}
