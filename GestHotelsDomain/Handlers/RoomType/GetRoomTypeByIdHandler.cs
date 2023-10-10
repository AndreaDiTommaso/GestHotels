using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestHotelsDomain.Queries.RoomType;
using GestHotelsDomain.Repositories.RoomType;
using MediatR;
namespace GestHotelsDomain.Handlers.RoomType
{
    public class GetRoomTypeByIdHandler : IRequestHandler<GetRoomTypeByIdQuery, Entities.RoomType>
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public GetRoomTypeByIdHandler(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }
        public async Task<Entities.RoomType> Handle(GetRoomTypeByIdQuery query, CancellationToken cancellationToken)
        {
            return await _roomTypeRepository.GetRoomTypeByIdAsync(query.Id);
        }
    }
}
