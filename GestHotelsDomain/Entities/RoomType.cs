
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GestHotelsDomain.Entities
{

    public class RoomType
    {
        
        public int Id { get; private set; }
        public string? Name { get; set; }
        public string? TypeName { get; set; }
        
        public List<Price>? PriceList { get; private set; }

        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        public int Cardinality { get; set; }
        public int TopMarginPercentage { get; set; }
        public int DownMarginPercentage { get; set; }

        //public void Modify(RoomType newRoomType)
        //{
        //    if (newRoomType.Name != null)
        //    {
        //        this.Name = newRoomType.Name;
        //    }
        //    if (newRoomType.TypeName != null)
        //    {
        //        this.TypeName = newRoomType.TypeName;
        //    }
        //    if (newRoomType.HotelId != 0)
        //    {
        //        this.HotelId = newRoomType.HotelId;
        //    }
        //    if (newRoomType.Cardnality != 0)
        //    {
        //        this.Cardnality = newRoomType.Cardnality;
        //    }
        //    if (newRoomType.TopMarginPercentage != 0)
        //    {
        //        this.TopMarginPercentage = newRoomType.TopMarginPercentage;
        //    }
        //    if (newRoomType.DownMarginPercentage != 0)
        //    {
        //        this.DownMarginPercentage = newRoomType.DownMarginPercentage;
        //    }
        //}
    }
}
