using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ParkingTicket : BEntity
    {
        public bool? IsActive { get; set; }

        public int? Hours { get; set; }

        public string? CarRegistrationNumber { get; set; }
        public string? DeviceID { get; set; }

        public DateTime? EndTime { get; set; }
        public DateTime? StartTime { get; set; }


        public int? CityCouncilId { get; set; }
        [ForeignKey("CityCouncilId")]
        public CityCouncil? CityCouncil { get; set; }

        public int? ParkingTicketCostId { get; set; }
        [ForeignKey("ParkingTicketCostId")]
        public ParkingTicketCost? ParkingTicketCost { get; set; }

        public int? ParkingTicketPaymentId { get; set; }
        [ForeignKey("ParkingTicketPaymentId")]
        public ParkingTicketPayment? ParkingTicketPayment { get; set; }
    }
}
