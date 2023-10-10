using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestHotelsDomain.Queries.Price;
using GestHotelsDomain.Repositories.Price;
using MediatR;
namespace GestHotelsDomain.Handlers.Price
{
    public class GetPriceListHandler : IRequestHandler<GetPriceListQuery, List<Entities.Price>>
    {
    
        private readonly IPriceRepository _priceRepository;

        public GetPriceListHandler(IPriceRepository priceRepository)
        {
            _priceRepository = priceRepository;;
        }

        public async Task<List<Entities.Price>> Handle(GetPriceListQuery query, CancellationToken cancellationToken)
        {
            return await _priceRepository.GetPriceListAsync();
        }
    }
}
