using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestHotelsDomain.Entities
{
    public class Price
    {
        [ForeignKey("PriceList")]
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public DateTime Date { get; set; }
        public int PriceListId { get; set; }
    }
}
