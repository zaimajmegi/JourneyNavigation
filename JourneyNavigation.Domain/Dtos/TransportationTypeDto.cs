using JourneyNavigation.API.Extensions;
using JourneyNavigation.Domain.Models;

namespace JourneyNavigation.Domain.Dtos
{
    public class TransportationTypeDto : BaseDto<TransportationTypeDto, TransportationType>
    {
        public string Transportation { get; set; } = string.Empty;
    }
}
