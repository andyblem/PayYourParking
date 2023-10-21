using Domain.Common.DTOs.SharedDTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.CQRS.CityCouncilCQRS.Queries
{
    public class GetCityCouncilSelectItemsQuery : IRequest<IEnumerable<SelectItemDTO<int>>>
    {
    }

    public class GetCityCouncilSelectItemsQueryHandler : IRequestHandler<GetCityCouncilSelectItemsQuery, IEnumerable<SelectItemDTO<int>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCityCouncilSelectItemsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SelectItemDTO<int>>> Handle(GetCityCouncilSelectItemsQuery request, CancellationToken cancellationToken)
        {
            // get data
            var cityCouncilSelectItems = await _dbContext.CityCouncils
                .Select(x => new SelectItemDTO<int>()
                {
                    Label = x.Name,
                    Value = x.Id
                })
                .ToListAsync();

            // return result
            return cityCouncilSelectItems;  
        }
    }
}
