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
    public class UpdatePriceHandler : IRequestHandler<UpdatePriceCommand, string>
    {
    
        private readonly IPriceRepository _priceRepository;

        public UpdatePriceHandler(IPriceRepository priceRepository)
        {
            _priceRepository = priceRepository;
        }
        public async Task<string> Handle(UpdatePriceCommand command, CancellationToken cancellationToken)
        {
            var price = await _priceRepository.GetPriceByIdAsync(command.Id);
            if (price == null)
                return String.Format("Price with id = {0} not found", command.Id);

            if (command.Cost != 0)
            {
                price.Cost = command.Cost;
            }
            if (command.Date != new DateTime(1, 1, 1))
            {
                price.Date = command.Date;
            }
            if (command.RoomTypeId != 0)
            {
                price.RoomTypeId = command.RoomTypeId;
            }

            return await _priceRepository.UpdatePriceAsync(price);
        }
    }
}
