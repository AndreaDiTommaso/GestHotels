using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace GestHotelsDomain.Queries.Hotel
{
    public class GetHotelByIdQuery : IRequest<Entities.Hotel>
    {
        public int Id { get; set; }
    }
}
