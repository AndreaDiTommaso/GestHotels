using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestHotelsDomain.Entities;
using MediatR;
namespace GestHotelsDomain.Commands.Hotel
{
    public class UpdateHotelCommand : IRequest<int>
    {
        public int Id { get; private set; }
        public string? Name { get; set; }
        public string? Address { get; set; }

        public int Stars { get; set; }

        public UpdateHotelCommand(int id, string? name, string? address, int stars )
        {
            Id = id;
            Name = name;
            Address = address;
            Stars = stars;
        }
    }
}
