using AutoMapper;
using Domain.Common.DTOs;
using Domain.Entities;
using MediatR;
using Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.CQRS.ParkingTicketCQRS.Commands
{
    public class CreateParkingTicketCommand : IRequest<ParkingTicket>
    {
        public ParkingTicket ParkingTicket { get; set; }
    }

    public class CreateParkingTicketCommandHandler : IRequestHandler<CreateParkingTicketCommand, ParkingTicket>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;

        public CreateParkingTicketCommandHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ParkingTicket> Handle(CreateParkingTicketCommand request, CancellationToken cancellationToken)
        {
            // get data
            var parkingTicket = request.ParkingTicket;

            // create record
            _dbContext.Add(parkingTicket);
            await _dbContext.SaveChangesAsync();

            // return result
            return parkingTicket;
        }
    }

}
