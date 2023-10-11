using GestHotelsDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace GestHotelsDomain.Commands.Price
{
    public class CreatePriceCommand : IRequest<string>
    {

        public decimal Cost { get; set; }
        public int RoomTypeId { get; set; }
        public DateTime Date { get; set; }
        public CreatePriceCommand(decimal cost, int roomTypeId, DateTime date)
        {
            Cost = cost;
            RoomTypeId = roomTypeId;
            Date = date;
        }
    }
}
