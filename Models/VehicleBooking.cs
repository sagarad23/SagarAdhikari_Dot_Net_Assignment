using System.ComponentModel.DataAnnotations;

namespace VehicleServiceBookingApp.Models
{
    public class VehicleBooking
    {
        public int  Id { get; set; }

        [Required]
        public required string CustomerName { get; set; }

        [Required]
        public required string VehicleNumber { get; set; }

        [DataType(DataType.Date)]
        public required DateTime ServiceDate { get; set; }

        [Required]
        public required string ServiceType { get; set; }
    }
}

