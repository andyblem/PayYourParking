using AutoMapper;
using Domain.Common.DTOs;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using Payment.Services;
using Persistance.CQRS.ParkingTicketCQRS.Commands;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webdev.Core;

namespace Application.Features
{
    public class CreateParkingTicketService : IRequest<Response<CreateParkingTicketResultDTO>>
    {
        public CreateParkingTicketDTO CreateParkingTicketDTO { get; set; }
    }

    public class CreateParkingTicketServiceHandler : IRequestHandler<CreateParkingTicketService, Response<CreateParkingTicketResultDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateParkingTicketServiceHandler(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<Response<CreateParkingTicketResultDTO>> Handle(CreateParkingTicketService request, CancellationToken cancellationToken)
        {
            // create payment dto
            CreatePaymentDTO createMobilePaymentDTO = _mapper.Map<CreatePaymentDTO>(request.CreateParkingTicketDTO);

            // make payment
            var paymentResponse = await _mediator.Send(new MakePaymentService()
            {
                CreatePaymentDTO = createMobilePaymentDTO
            });

            if (paymentResponse.Success() == true)
            {
                // create objects
                var parkingTicket = _mapper.Map<ParkingTicket>(request.CreateParkingTicketDTO);
                var parkingTicketPayment = _mapper.Map<ParkingTicketPayment>(paymentResponse);

                // map other data
                parkingTicketPayment.Amount = request.CreateParkingTicketDTO.Amount;
                parkingTicketPayment.Email = request.CreateParkingTicketDTO.Email;
                parkingTicketPayment.PaymentPlatform = request.CreateParkingTicketDTO.MobileMoney;
                parkingTicketPayment.PhoneNumber = request.CreateParkingTicketDTO.PhoneNumber;

                // update payment data
                parkingTicket.ParkingTicketPayment = parkingTicketPayment;

                // update parking ticket model
                parkingTicket.IsActive = true;
                parkingTicket.StartTime = DateTime.Now;
                parkingTicket.EndTime = parkingTicket.StartTime.Value.AddHours(request.CreateParkingTicketDTO.Hours);


                // save payment result to db
                parkingTicket = await _mediator.Send(new CreateParkingTicketCommand()
                {
                    ParkingTicket = parkingTicket
                });

                // map to response
                var createParkingTicketResult = _mapper.Map<CreateParkingTicketResultDTO>(parkingTicket);
                
                // return result
                return new Response<CreateParkingTicketResultDTO>(createParkingTicketResult);
            }
            else
            {
                // return result
                return new Response<CreateParkingTicketResultDTO>("Failed to process payment");
            }
        }
    }
}
