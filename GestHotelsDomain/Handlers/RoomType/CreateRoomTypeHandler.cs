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
    public class CreateRoomTypeHandler : IRequestHandler<CreateRoomTypeCommand, string>
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public CreateRoomTypeHandler(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }
        public async Task<string> Handle(CreateRoomTypeCommand command, CancellationToken cancellationToken)
        {
            var roomType = new Entities.RoomType()
            {
                Name = command.Name,
                TypeName = command.TypeName,
                HotelId = command.HotelId,
                Cardnality = command.Cardnality,
                TopMarginPercentage = command.TopMarginPercentage,
                DownMarginPercentage = command.DownMarginPercentage
            };

            return await _roomTypeRepository.AddRoomTypeAsync(roomType);
        }
    }
}
