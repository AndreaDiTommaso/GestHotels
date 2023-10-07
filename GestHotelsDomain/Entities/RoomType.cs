using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestHotelsDomain.Entities
{
    public class RoomType
    {
      
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cardnality { get; set; }
        public int UpperBound { get; set; }
        public int LowerBound { get; set; }

        [ForeignKey("Room")]
        public int RoomId { get; set; }
       
    }
}
