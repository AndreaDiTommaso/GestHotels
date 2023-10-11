using GestHotelsDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace GestHotelsDomain.Commands.Hotel
{
    public class CreateHotelCommand : IRequest<string>
    {
      
        public string? Name { get; set; }
        public string? Adress { get; set; }
       
        public int Stars { get; set; }

        public CreateHotelCommand( string? name, string? adress, int stars)
        {
            Name = name;
            Adress = adress;
            Stars = stars;
        }
    }
}
