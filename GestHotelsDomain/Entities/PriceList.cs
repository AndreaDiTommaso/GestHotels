using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestHotelsDomain.Entities
{
    public class PriceList
    {
        
        public int Id { get; set; }

        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public List<Price> Prices { get; set; }
        
    }
}
