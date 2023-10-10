using GestHotelsDomain.Commands.Price;
using GestHotelsDomain.Repositories.Price;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace GestHotelsDomain.Handlers.Price
{
    public class CreatePriceHandler : IRequestHandler<CreatePriceCommand, Entities.Price>
    {
        private readonly IPriceRepository _priceRepository;

        public CreatePriceHandler(IPriceRepository priceRepository)
        {
            _priceRepository = priceRepository;
        }
        public async Task<Entities.Price> Handle(CreatePriceCommand command, CancellationToken cancellationToken)
        {
            var price = new Entities.Price()
            {
                Cost = command.Cost,
                Date = command.Date,
                RoomTypeId = command.RoomTypeId
            };

            return await _priceRepository.AddPriceAsync(price);
        }
    }
}
