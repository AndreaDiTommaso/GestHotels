using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestHotelsDomain.Entities
{
    public class Room
    {
        [ForeignKey("Hotel")]
        public int Id { get; set; }
        public string Name { get; set; }
        public RoomType Type { get; set; }
        public int HotelId { get; set; }
        public PriceList PriceList { get; set; }
    }
}
