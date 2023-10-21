using Domain.Common.DTOs.ParkingTicketDTOs;
using MediatR;
using Persistance.CQRS.CityCouncilCQRS.Queries;
using Persistance.CQRS.PaymentPlatformCQRS.Queries;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ParkingTickets
{
    public class GetCreateParkingTicketInitDataService : IRequest<Response<CreateParkingTicketInitDataDTO>>
    {
    }

    public class GetCreateParkingTicketInitDataServiceHandler : IRequestHandler<GetCreateParkingTicketInitDataService, Response<CreateParkingTicketInitDataDTO>>
    {
        private readonly IMediator _mediator;

        public GetCreateParkingTicketInitDataServiceHandler(IMediator mediator)
        {
            _mediator = mediator;
        }


        public async Task<Response<CreateParkingTicketInitDataDTO>> Handle(GetCreateParkingTicketInitDataService request, CancellationToken cancellationToken)
        {
            // create dto
            CreateParkingTicketInitDataDTO createParkingTicketInitDataDTO = new CreateParkingTicketInitDataDTO();

            // init view model
            createParkingTicketInitDataDTO.CityCouncilSelectItems = await _mediator.Send(new GetCityCouncilSelectItemsQuery());
            createParkingTicketInitDataDTO.PaymentPlatformSelectItems = await _mediator.Send(new GetPaymentPlatformSelectItemsQuery());

            // return result
            return new Response<CreateParkingTicketInitDataDTO>(createParkingTicketInitDataDTO);
        }
    }
}
