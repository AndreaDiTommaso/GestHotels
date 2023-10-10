using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace GestHotelsDomain.Queries.RoomType
{
    public class GetRoomTypeListQuery : IRequest<List<Entities.RoomType>>
    {
    }
}
