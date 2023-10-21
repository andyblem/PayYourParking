using Domain.Common.DTOs;
using MediatR;
using Microsoft.Extensions.Configuration;
using Shared.Wrappers;
using Webdev.Core;
using Webdev.Payments;

namespace Payment.Services
{
    public class MakePaymentService : IRequest<InitResponse>
    {
        public CreatePaymentDTO CreatePaymentDTO { get; set; }
    }

    public class MakePaymentServiceHandler : IRequestHandler<MakePaymentService, InitResponse>
    {
        private readonly IConfiguration _configuration;

        public MakePaymentServiceHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<InitResponse> Handle(MakePaymentService request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                // get data
                string authEmail = _configuration.GetSection("PayNow:Auth.Email").Value;
                string integrationId = _configuration.GetSection("PayNow:Integration.ID").Value;
                string integrationKey = _configuration.GetSection("PayNow:Integration.Key").Value;

                // create new Paynow object
                var paynow = new Paynow(integrationId,
                    integrationKey);

                // create payment object
                string invoiceString = string.Format("Invoice: {0}", DateTime.Now);
                var payment = paynow.CreatePayment(invoiceString,
                    authEmail);


                // add items to the payment
                payment.Add("Parking Ticket",
                    (decimal)request.CreatePaymentDTO.Amount);

                // make request
                var response = paynow.SendMobile(payment,
                    request.CreatePaymentDTO.PhoneNumber,
                    request.CreatePaymentDTO.MobileMoney);

                // return result
                return response;
            });
        }
    }
}
