using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestHotelsDomain.Entities;
using MediatR;
namespace GestHotelsDomain.Commands.RoomType
{
    public class UpdateRoomTypeCommand : IRequest<string>
    {
        public int Id { get; private set; }
        public string? Name { get; set; }
        public string? TypeName { get; set; }
        public int HotelId { get; set; }
        public int Cardinality { get; set; }
        public int TopMarginPercentage { get; set; }
        public int DownMarginPercentage { get; set; }
        public UpdateRoomTypeCommand(int id, string? name, string? typeName, int hotelId, int cardinality,  int topMarginPercentage, int downMarginPercentage)
        {
            Id = id;
            Name = name;
            TypeName = typeName;
            HotelId = hotelId;
            Cardinality = cardinality;
            TopMarginPercentage = topMarginPercentage;
            DownMarginPercentage = downMarginPercentage;
        }
    }
}
