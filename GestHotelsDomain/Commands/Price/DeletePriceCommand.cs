using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace GestHotelsDomain.Commands.Price
{
    public class DeletePriceCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
