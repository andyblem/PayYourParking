using Application.Features.ParkingTickets;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class GetUserParkingTicketsServiceValidator : AbstractValidator<GetUserParkingTicketsService>
    {
        public GetUserParkingTicketsServiceValidator()
        {
            RuleFor(x => x.DeviceId).NotEmpty();
        }
    }
}
