using AutoMapper;
using Domain.Common.DTOs.ParkingTicketDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AutoMapper.Mappings
{
    public class ParkingTicketProfiles : Profile
    {
        public ParkingTicketProfiles()
        {
            CreateMap<CreateParkingTicketDTO, CreatePaymentDTO>();
            CreateMap<CreateParkingTicketDTO, ParkingTicket>();

            CreateMap<ParkingTicket, CreateParkingTicketResultDTO>()
                .ForMember(d => d.CityCouncil, d => d.MapFrom(x => x.CityCouncil.Name))
                .ForMember(d => d.ServiceId, d => d.MapFrom(x => x.Id))
                .ForMember(d => d.MobileMoney, d => d.MapFrom(x => x.ParkingTicketPayment.PaymentPlatform));
        }
    }
}
