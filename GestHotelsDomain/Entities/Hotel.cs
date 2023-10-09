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
       // [JsonIgnore(IgnoreDeserialize = false)]
        public int Id { get; private set; }
        public string? Name { get; set; }
        public string? Adress { get; set; }
        [Range(0, 5)]
        public int Stars { get; set; }
        
        public List<RoomType>? Rooms { get; private set; }

        public void Modify(Hotel newHotel)
        {
            if (newHotel.Name != null)
            {
                this.Name = newHotel.Name;
            }
            if (newHotel.Adress != null)
            {
                this.Adress = newHotel.Adress;
            }
            if (newHotel.Stars != 0)
            {
                this.Stars = newHotel.Stars;
            }
        }
    }
}
