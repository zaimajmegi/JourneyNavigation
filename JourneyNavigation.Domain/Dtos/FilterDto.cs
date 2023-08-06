using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyNavigation.Domain.Dtos
{
    public class FilterDto
    {
        public string UserId { get; set; }
        public int TransportationTypeId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ArrivalDate { get; set; }

    }
}
