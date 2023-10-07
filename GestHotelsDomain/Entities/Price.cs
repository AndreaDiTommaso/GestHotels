using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestHotelsDomain.Entities
{
    public class Price
    {
        public int Id { get; set; }
        public decimal Cost { get; set; }

        [Required]
        [ForeignKey("PriceList")]
        public int PriceListId { get; set; }

        [Required]
        public DateTime Date { get; set; }
       
    }
}