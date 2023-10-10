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
    public class GetRoomTypeListHandler : IRequestHandler<GetRoomTypeListQuery, List<Entities.RoomType>>
    {
    
        private readonly IRoomTypeRepository _roomTypeRepository;

        public GetRoomTypeListHandler(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;;
        }

        public async Task<List<Entities.RoomType>> Handle(GetRoomTypeListQuery query, CancellationToken cancellationToken)
        {
            return await _roomTypeRepository.GetRoomTypeListAsync();
        }
    }
}
