using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace GestHotelsDomain.Commands.Hotel
{
    public class DeleteHotelCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
