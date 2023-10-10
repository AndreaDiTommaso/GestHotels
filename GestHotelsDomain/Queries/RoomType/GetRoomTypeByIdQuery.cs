using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace GestHotelsDomain.Queries.RoomType
{
    public class GetRoomTypeByIdQuery : IRequest<Entities.RoomType>
    {
        public int Id { get; set; }
    }
}
