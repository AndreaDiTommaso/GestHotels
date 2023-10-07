using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestHotelsDomain.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        [Range(0, 5)]
        public int Stars { get; set; }

        public List<Room> Rooms { get; set; }


    }
}
