using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestHotelsDomain.Queries.Hotel;
using GestHotelsDomain.Repositories.Hotel;
using MediatR;
namespace GestHotelsDomain.Handlers.Hotel
{
    public class GetHotelByIdHandler : IRequestHandler<GetHotelByIdQuery, Entities.Hotel>
    {
        private readonly IHotelRepository _hotelRepository;

        public GetHotelByIdHandler(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public async Task<Entities.Hotel> Handle(GetHotelByIdQuery query, CancellationToken cancellationToken)
        {
            return await _hotelRepository.GetHotelByIdAsync(query.Id);
        }
    }
}
