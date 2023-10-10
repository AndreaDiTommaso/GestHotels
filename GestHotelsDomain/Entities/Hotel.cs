using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestHotelsDomain.Entities
{
    public class Hotel
    {
        public int Id { get; private set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        [Range(0, 5)]
        public int Stars { get; set; }
        
        public List<RoomType>? Rooms { get; private set; }

    }
}
