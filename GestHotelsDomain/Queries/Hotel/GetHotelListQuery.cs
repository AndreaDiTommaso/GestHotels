using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace GestHotelsDomain.Queries.Hotel
{
    public class GetHotelListQuery : IRequest<List<Entities.Hotel>>
    {
    }
}
