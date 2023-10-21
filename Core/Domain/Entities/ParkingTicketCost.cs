using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ParkingTicketCost : BEntity
    {
        public bool? IsActive { get; set; }

        public decimal? PricePerHour { get; set; }


        public int? CurrencyId { get; set; }
        [ForeignKey("CurrencyId")]
        public Currency? Currency { get; set; }
    }
}
