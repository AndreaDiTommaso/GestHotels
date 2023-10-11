using GestHotelsDomain.Commands.Hotel;
using GestHotelsDomain.Repositories.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace GestHotelsDomain.Handlers.Hotel
{
    public class CreateHotelHandler : IRequestHandler<CreateHotelCommand, string>
    {
        private readonly IHotelRepository _hotelRepository;

        public CreateHotelHandler(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public async Task<string> Handle(CreateHotelCommand command, CancellationToken cancellationToken)
        {
            var hotel = new Entities.Hotel()
            {
                Name = command.Name,
                Address = command.Adress,
                Stars = command.Stars
            };

            return await _hotelRepository.AddHotelAsync(hotel);
        }
    }
}
