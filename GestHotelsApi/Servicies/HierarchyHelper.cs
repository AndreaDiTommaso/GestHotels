using GestHotelsDomain;
using GestHotelsDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestHotelsApi.Servicies
{
    public class HierarchyHelper
    {
        public Hotel hotel;
        public RoomType room;
        public Price price;
        public HierarchyHelper(HotelDbContext context,Price price)
        {
            this.price = price;
            this.room = context.RoomType.FirstOrDefault(r => r.Id == price.RoomTypeId);
            this.hotel = context.Hotel
                .Include(h => h.Rooms)
                .ThenInclude(r => r.PriceList)
                .FirstOrDefault(h => h.Id == room.HotelId);
        }
        public  int GetPrevCardinality() 
        {
            int result = 0;
            try 
            {
                List<int> listLowerCardinality = this.hotel.Rooms.Select(r => r.Cardnality).Where(c => c < this.room.Cardnality).ToList();
                if (listLowerCardinality != null)
                {
                    result = listLowerCardinality.Max();
                }
                return result;
            }
            catch (Exception e) 
            {
                return -1;
            }

        }
        public int GetNextCardinality()
        {
            try
            {
                int result = 0;
                List<int> listUpperCardinality = this.hotel.Rooms.Select(r => r.Cardnality).Where(c => c > this.room.Cardnality).ToList();
                if (listUpperCardinality != null)
                {
                    result = listUpperCardinality.Min();
                }
                return result;
            }
            catch (Exception e)
            {
                return -1;
            }
           
        }
        public List<RoomType> GetByCardinality(int cardinality)
        {
            try
            {
                List<RoomType> roomTypes = new List<RoomType>();
                roomTypes = (List<RoomType>)this.hotel.Rooms.Select(r => r).Where(r => r.Cardnality == cardinality).ToList();
                return roomTypes;
            }
            catch (Exception e)
            {
                return null;
            }
           
        }
        public decimal GetMinCost(List<RoomType> rooms) 
        {
            try
            {
                List<decimal> costs = new List<decimal>();
                foreach (RoomType roomType in rooms)
                {
                    decimal actualCost = roomType.PriceList
                        .Select(p => p)
                        .Where(p => p.Date == this.price.Date)
                        .Select(p => p.Cost)
                        .FirstOrDefault();
                    costs.Add(actualCost);
                }
                return costs.Min();
            }
            catch (Exception e)
            {
                return -1;
            }
         
        }
        public decimal GetMaxCost(List<RoomType> rooms)
        {
            try
            {
                List<decimal> costs = new List<decimal>();
                foreach (RoomType roomType in rooms)
                {
                    decimal actualCost = roomType.PriceList
                        .Select(p => p)
                        .Where(p => p.Date == this.price.Date)
                        .Select(p => p.Cost)
                        .FirstOrDefault();
                    costs.Add(actualCost);
                }
                return costs.Max();
            }
            catch (Exception e)
            {
                return -1;
            }
           
        }
        public decimal GetUpperBound(decimal minUpperCost)
        {
           return minUpperCost - (this.price.Cost * this.room.TopMarginPercentage) / 100;

        }
        public decimal GetLowerBound(decimal maxLowerBound)
        {
            return maxLowerBound + (maxLowerBound * this.room.DownMarginPercentage) / 100;
        }
        public bool ValidateUpperBound(decimal upperBound)
        {
            if (this.price.Cost <= upperBound)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ValidateLowerBound(decimal lowerBound)
        {
            if (this.price.Cost >= lowerBound)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ValidatePrice()
        {

            int prevCardinality = GetPrevCardinality();
            decimal lowerBound=0;
            bool resultTop = false;
            bool resultDown = false;
            if (prevCardinality > 0)
            {
                
                try 
                {
                    List<RoomType> list = GetByCardinality(prevCardinality);
                    decimal maxCost = GetMaxCost(list);
                    lowerBound = GetLowerBound(maxCost);
                }
                catch 
                {
                    lowerBound = 0;
                }
               
            }
            if (lowerBound == 0)
            {
                resultDown = true;
            }
            else
            {
                resultDown = ValidateLowerBound(lowerBound);
            }
            int nextCardinality = GetNextCardinality();
            decimal upperBound=0;
            if (nextCardinality > 0)
            {
               
                try
                {
                    upperBound = GetUpperBound(GetMinCost(GetByCardinality(nextCardinality)));
                }
                catch
                {
                    upperBound = 0;
                }
                
            }
            if (upperBound == 0)
            {
                resultTop = true;
            }
            else
            {
                resultTop = ValidateUpperBound(upperBound);
            }
            if (resultTop && resultDown)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
