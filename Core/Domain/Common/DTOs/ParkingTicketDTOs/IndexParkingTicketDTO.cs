using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.DTOs.ParkingTicketDTOs
{
    public class IndexParkingTicketDTO
    {
        public bool? IsActive { get; set; }

        public int Hours { get; set; }
        public int ServiceId { get; set; }

        public string CarRegistrationNumber { get; set; }
        public string CityCouncil { get; set; }
        public string PaymentPlatform { get; set; }

        public DateTime EndTime { get; set; }
        public DateTime StartTime { get; set; }
    }
}
