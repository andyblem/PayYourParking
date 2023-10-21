using Domain.Common.DTOs.ParkingTicketDTOs;
using MediatR;
using Persistance.CQRS.ParkingTicketCQRS.Queries;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ParkingTickets
{
    public class GetUserParkingTicketsService : IRequest<Response<IEnumerable<IndexParkingTicketDTO>>>
    {
        public string DeviceId { get; set; }
    }

    public class GetUserParkingTicketsServiceHandler : IRequestHandler<GetUserParkingTicketsService, Response<IEnumerable<IndexParkingTicketDTO>>>
    {
        private readonly IMediator _mediator;

        public GetUserParkingTicketsServiceHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Response<IEnumerable<IndexParkingTicketDTO>>> Handle(GetUserParkingTicketsService request, CancellationToken cancellationToken)
        {
            // get data
            var parkingTickets = await _mediator.Send(new GetUserParkingTicketsQuery()
            {
                DeviceId = request.DeviceId,
            });

            // return result
            return new Response<IEnumerable<IndexParkingTicketDTO>>(parkingTickets);
        }
    }
}
