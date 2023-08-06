using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyNavigation.Domain.Models
{
    public class Journey
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string StartLocation { get; set; } = string.Empty;
        [Required]
        [MaxLength(250)]
        public string ArrivalLocation { get; set; } = string.Empty;
        [Required]
        public decimal DistanceInKm { get; set; }
        public User? JourneyUser { get; set; }
        public string? JourneyUserId { get; set; }
        public TransportationType? TransportationType { get; set; }
        public int? TransportationTypeId { get; set; }
        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime ArrivalTime { get; set; }

    }
}
