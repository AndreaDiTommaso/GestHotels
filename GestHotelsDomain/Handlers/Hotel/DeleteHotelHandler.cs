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
    public class DeleteHotelHandler : IRequestHandler<DeleteHotelCommand, string>
    {
        private readonly IHotelRepository _hotelRepository;

        public DeleteHotelHandler(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public async Task<string> Handle(DeleteHotelCommand command, CancellationToken cancellationToken)
        {
            var hotel = await _hotelRepository.GetHotelByIdAsync(command.Id);
            if (hotel == null)
                return String.Format("Hotel with id = {0} not found", command.Id);


            return await _hotelRepository.DeleteHotelAsync(hotel.Id);
        }
    }
}
