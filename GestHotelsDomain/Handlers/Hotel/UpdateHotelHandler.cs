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
    public class UpdateHotelHandler : IRequestHandler<UpdateHotelCommand, int>
    {
    
        private readonly IHotelRepository _hotelRepository;

        public UpdateHotelHandler(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public async Task<int> Handle(UpdateHotelCommand command, CancellationToken cancellationToken)
        {
            var hotel = await _hotelRepository.GetHotelByIdAsync(command.Id);
            if (hotel == null)
                return default;
            if (command.Name != null)
            {
                hotel.Name = command.Name;
            }
            if (command.Address != null)
            {
                hotel.Address = command.Address;
            }
            if (command.Stars != 0)
            {
                hotel.Stars = command.Stars;
            }

            return await _hotelRepository.UpdateHotelAsync(hotel);
        }
    }
}
