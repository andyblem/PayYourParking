using Domain.Common.DTOs.ParkingTicketDTOs;
using MediatR;
using Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.CQRS.ParkingTicketCQRS.Queries
{
    public class GetUserParkingTicketsQuery : IRequest<IEnumerable<IndexParkingTicketDTO>>
    {
        public string DeviceId { get; set; }
    }

    public class GetUserParkingTicketsQueryHandler : IRequestHandler<GetUserParkingTicketsQuery, IEnumerable<IndexParkingTicketDTO>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetUserParkingTicketsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<IndexParkingTicketDTO>> Handle(GetUserParkingTicketsQuery request, CancellationToken cancellationToken)
        {
            var parkingTickets = await _dbContext.ParkingTickets
                .Where(pT => pT.IsActive == true && pT.DeviceID == request.DeviceId)
                .Select(pT => new IndexParkingTicketDTO()
                {
                    IsActive = pT.IsActive,

                    Hours = (int)pT.Hours,
                    ServiceId = pT.Id,

                    CarRegistrationNumber = pT.CarRegistrationNumber,
                    CityCouncil = pT.CityCouncil.Name,
                    PaymentPlatform = pT.ParkingTicketPayment.MobileMoney,

                    EndTime = (DateTime)pT.EndTime,
                    StartTime = (DateTime)pT.StartTime,
                })
                .ToListAsync();

            // return result
            return parkingTickets;
        }
    }
}
