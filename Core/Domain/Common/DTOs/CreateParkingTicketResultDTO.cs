using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.DTOs
{
    public class CreateParkingTicketResultDTO
    {
        public bool IsActive { get; set; }

        public int Hours { get; set; }
        public int ServiceId { get; set; }

        public string CarRegistrationNumber { get; set; }
        public string CityCouncil { get; set; }
        public string MobileMoney { get; set; }

        public DateTime EndTime { get; set; }
        public DateTime StartTime { get; set; }
    }
}
