using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.DTOs
{
    public class CreateParkingTicketDTO
    {
        public decimal? Amount { get; set; }
        public decimal? PricePerHour { get; set; }

        public int CityCouncilId { get; set; }
        public int Hours { get; set; }
        public int ParkingTicketCostId { get; set; }

        public string CarRegistrationNumber { get; set; }
        public string DeviceID { get; set; }
        public string Email { get; set; }
        public string MobileMoney { get; set; }
        public string PollUrl { get; set; }
        public string PhoneNumber { get; set; }
    }
}
