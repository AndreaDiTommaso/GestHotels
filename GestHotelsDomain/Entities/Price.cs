using Microsoft.EntityFrameworkCore;
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
    public class Price
    {

        public int Id { get; private set; }
        public decimal Cost { get; set; }

        [Required]
        [ForeignKey("RoomType")]
        public int RoomTypeId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public void Modify(Price newPrice)
        {
            if (newPrice.Cost != 0)
            {
                this.Cost = newPrice.Cost;
            }
            if (newPrice.Date != new DateTime(1,1,1))
            {
                //01 / 01 / 0001 00:00:00
                this.Date = newPrice.Date;
            }
            if (newPrice.RoomTypeId != 0)
            {
                this.RoomTypeId = newPrice.RoomTypeId;
            }
        }
    }
}