using GestHotelsDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace GestHotelsDomain.Commands.RoomType
{
    public class CreateRoomTypeCommand : IRequest<string>
    {
        
        public string? Name { get; set; }
        public string? TypeName { get; set; }
        public int HotelId { get; set; }
        public int Cardnality { get; set; }
        public int TopMarginPercentage { get; set; }
        public int DownMarginPercentage { get; set; }
        public CreateRoomTypeCommand(string? name, string? typeName, int hotelId, int cardnality, int topMarginPercentage, int downMarginPercentage)
        {
            Name = name;
            TypeName = typeName;
            HotelId = hotelId;
            Cardnality = cardnality;
            TopMarginPercentage = topMarginPercentage;
            DownMarginPercentage = downMarginPercentage;
        }
    }
}
