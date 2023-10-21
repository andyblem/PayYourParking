using AutoMapper;
using Domain.Entities;
using Webdev.Core;

namespace Application.AutoMapper.Mappings
{
    public class ParkingTicketPaymentProfiles : Profile
    {
        public ParkingTicketPaymentProfiles()
        {
            CreateMap<InitResponse, ParkingTicketPayment>()
                .ForMember(d => d.Instructions, d => d.MapFrom(x => x.GetData()["instructions"]))
                .ForMember(d => d.PaymentHash, d => d.MapFrom(x => x.GetData()["hash"]))
                .ForMember(d => d.PaymentReferrence, d => d.MapFrom(x => x.GetData()["paynowreference"]))
                .ForMember(d => d.PollUrl, d => d.MapFrom(x => x.GetData()["pollurl"]));

        }
    }
}
