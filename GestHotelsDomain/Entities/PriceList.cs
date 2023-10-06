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
        [ForeignKey("Room")]
        public int Id { get; set; }

        public List<Price> Prices { get; set; }
        
    }
}
