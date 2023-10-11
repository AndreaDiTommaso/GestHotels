using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestHotelsDomain.Entities;
using MediatR;
namespace GestHotelsDomain.Commands.Price
{
    public class UpdatePriceCommand : IRequest<string>
    {
        public int Id { get; private set; }
        public decimal Cost { get; set; }
        public int RoomTypeId { get; set; }
        public DateTime Date { get; set; }
        public UpdatePriceCommand(int id, decimal cost, int roomTypeId, DateTime date)
        {
            Id = id;
            Cost = cost;
            RoomTypeId = roomTypeId;
            Date = date;
        }
    }
}
