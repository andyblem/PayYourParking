using Domain.Common.DTOs.SharedDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.DTOs.ParkingTicketDTOs
{
    public class CreateParkingTicketInitDataDTO
    {
        public IEnumerable<SelectItemDTO<int>>? CityCouncilSelectItems { get; set; }
        public IEnumerable<SelectItemDTO<int>>? PaymentPlatformSelectItems { get; set; }
    }

}
