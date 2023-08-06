using System.ComponentModel.DataAnnotations;
using JourneyNavigation.API.Extensions;
using JourneyNavigation.Domain.Models;

namespace JourneyNavigation.Domain.Dtos
{
    public class JourneyDto : BaseDto<JourneyDto, Journey>
    {
        [MaxLength(250)]
        public string StartLocation { get; set; } = string.Empty;
        [MaxLength(250)]
        public string ArrivalLocation { get; set; } = string.Empty;
        public decimal DistanceInKm { get; set; }
        public string? JourneyUserId { get; set; }
        public int? TransportationTypeId { get; set; }
        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime ArrivalTime { get; set; }
    }
}
