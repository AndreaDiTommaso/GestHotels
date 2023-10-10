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
    public class UpdateRoomTypeHandler : IRequestHandler<UpdateRoomTypeCommand, int>
    {
    
        private readonly IRoomTypeRepository _roomTypeRepository;

        public UpdateRoomTypeHandler(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }
        public async Task<int> Handle(UpdateRoomTypeCommand command, CancellationToken cancellationToken)
        {
            var roomType = await _roomTypeRepository.GetRoomTypeByIdAsync(command.Id);
            if (roomType == null)
                return default;
            if (command.Name != null)
            {
                roomType.Name = command.Name;
            }
            if (command.TypeName != null)
            {
                roomType.TypeName = command.TypeName;
            }
            if (command.HotelId != 0)
            {
                roomType.HotelId = command.HotelId;
            }
            if (command.Cardnality != 0)
            {
                roomType.Cardnality = command.Cardnality;
            }
            if (command.TopMarginPercentage != 0)
            {
                roomType.TopMarginPercentage = command.TopMarginPercentage;
            }
            if (command.DownMarginPercentage != 0)
            {
                roomType.DownMarginPercentage = command.DownMarginPercentage;
            }

            return await _roomTypeRepository.UpdateRoomTypeAsync(roomType);
        }
    }
}
