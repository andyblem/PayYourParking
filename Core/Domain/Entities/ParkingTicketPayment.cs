using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ParkingTicketPayment : BEntity
    {
        public decimal? Amount { get; set; }

        public string? Email { get; set; }
        public string? Instructions { get; set; }
        public string? MobileMoney { get; set; }
        public string? PayNowHash { get; set; }
        public string? PayNowReferrence { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PollUrl { get; set; }
    }
}
