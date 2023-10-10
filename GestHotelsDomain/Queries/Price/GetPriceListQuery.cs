using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace GestHotelsDomain.Queries.Price
{
    public class GetPriceListQuery : IRequest<List<Entities.Price>>
    {
    }
}
