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
    public class DeletePriceHandler : IRequestHandler<DeletePriceCommand, string>
    {
        private readonly IPriceRepository _priceRepository;

        public DeletePriceHandler(IPriceRepository priceRepository)
        {
            _priceRepository = priceRepository;
        }
        public async Task<string> Handle(DeletePriceCommand command, CancellationToken cancellationToken)
        {
            var hotel = await _priceRepository.GetPriceByIdAsync(command.Id);
            if (hotel == null)
                return String.Format("Price with id = {0} not found", command.Id);

            return await _priceRepository.DeletePriceAsync(hotel.Id);
        }
    }
}
