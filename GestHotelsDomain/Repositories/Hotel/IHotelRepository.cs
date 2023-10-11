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
        public Task<string> AddHotelAsync(Entities.Hotel hotel);
        public Task<string> UpdateHotelAsync(Entities.Hotel hotel);
        public Task<string> DeleteHotelAsync(int Id);
    }
}
