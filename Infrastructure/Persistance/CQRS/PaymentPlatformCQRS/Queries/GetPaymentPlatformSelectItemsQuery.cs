using Domain.Common.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;
using Persistance.CQRS.PaymentPlatformCQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.CQRS.PaymentPlatformCQRS.Queries
{
    public class GetPaymentPlatformSelectItemsQuery : IRequest<IEnumerable<SelectItemDTO<int>>>
    {
    }

    public class GetPaymentPlatformSelectItemsQueryHandler : IRequestHandler<GetPaymentPlatformSelectItemsQuery, IEnumerable<SelectItemDTO<int>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetPaymentPlatformSelectItemsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SelectItemDTO<int>>> Handle(GetPaymentPlatformSelectItemsQuery request, CancellationToken cancellationToken)
        {
            // get data
            var paymentPlatformSelectItems = await _dbContext.PaymentPlatforms
                .Select(x => new SelectItemDTO<int>()
                {
                    Label = x.Name,
                    Value = x.Id
                })
                .ToListAsync();

            // return result
            return paymentPlatformSelectItems;
        }
    }

}
