using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GestHotelsDomain.Repositories.Hotel
{
    public interface IHotelRepository
    {
        public Task<List<Entities.Hotel>> GetHotelListAsync();
        public Task<Entities.Hotel> GetHotelByIdAsync(int Id);
        public Task<Entities.Hotel> AddHotelAsync(Entities.Hotel hotel);
        public Task<int> UpdateHotelAsync(Entities.Hotel hotel);
        public Task<int> DeleteHotelAsync(int Id);
    }
}
