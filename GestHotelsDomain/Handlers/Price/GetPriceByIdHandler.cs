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
    public class GetPriceByIdHandler : IRequestHandler<GetPriceByIdQuery, Entities.Price>
    {
        private readonly IPriceRepository _priceRepository;

        public GetPriceByIdHandler(IPriceRepository priceRepository)
        {
            _priceRepository = priceRepository;
        }
        public async Task<Entities.Price> Handle(GetPriceByIdQuery query, CancellationToken cancellationToken)
        {
            return await _priceRepository.GetPriceByIdAsync(query.Id);
        }
    }
}
