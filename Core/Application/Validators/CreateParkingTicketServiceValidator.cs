using Application.Features.ParkingTickets;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class CreateParkingTicketServiceValidator : AbstractValidator<CreateParkingTicketService>
    {
        public CreateParkingTicketServiceValidator()
        {
            RuleFor(x => x.CreateParkingTicketDTO).NotEmpty();

            RuleFor(x => x.CreateParkingTicketDTO.Amount).NotEmpty();
            RuleFor(x => x.CreateParkingTicketDTO.CarRegistrationNumber).NotEmpty();
            RuleFor(x => x.CreateParkingTicketDTO.CityCouncilId).NotEmpty();
            RuleFor(x => x.CreateParkingTicketDTO.DeviceID).NotEmpty();
            RuleFor(x => x.CreateParkingTicketDTO.Email).NotEmpty();
            RuleFor(x => x.CreateParkingTicketDTO.Hours).NotEmpty();
            RuleFor(x => x.CreateParkingTicketDTO.MobileMoney).NotEmpty();
            RuleFor(x => x.CreateParkingTicketDTO.ParkingTicketCostId).NotEmpty();
            RuleFor(x => x.CreateParkingTicketDTO.PricePerHour).NotEmpty();
            RuleFor(x => x.CreateParkingTicketDTO.PhoneNumber).NotEmpty();
        }
    }
}
