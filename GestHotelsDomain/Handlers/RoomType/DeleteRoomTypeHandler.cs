using GestHotelsDomain.Commands.RoomType;
using GestHotelsDomain.Repositories.RoomType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace GestHotelsDomain.Handlers.RoomType
{
    public class DeleteRoomTypeHandler : IRequestHandler<DeleteRoomTypeCommand, int>
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public DeleteRoomTypeHandler(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }
        public async Task<int> Handle(DeleteRoomTypeCommand command, CancellationToken cancellationToken)
        {
            var hotel = await _roomTypeRepository.GetRoomTypeByIdAsync(command.Id);
            if (hotel == null)
                return default;

            return await _roomTypeRepository.DeleteRoomTypeAsync(hotel.Id);
        }
    }
}
