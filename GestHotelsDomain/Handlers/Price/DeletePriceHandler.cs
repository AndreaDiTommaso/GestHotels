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
    public class DeletePriceHandler : IRequestHandler<DeletePriceCommand, int>
    {
        private readonly IPriceRepository _priceRepository;

        public DeletePriceHandler(IPriceRepository priceRepository)
        {
            _priceRepository = priceRepository;
        }
        public async Task<int> Handle(DeletePriceCommand command, CancellationToken cancellationToken)
        {
            var hotel = await _priceRepository.GetPriceByIdAsync(command.Id);
            if (hotel == null)
                return default;

            return await _priceRepository.DeletePriceAsync(hotel.Id);
        }
    }
}
