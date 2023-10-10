using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace GestHotelsDomain.Queries.Price
{
    public class GetPriceByIdQuery : IRequest<Entities.Price>
    {
        public int Id { get; set; }
    }
}
