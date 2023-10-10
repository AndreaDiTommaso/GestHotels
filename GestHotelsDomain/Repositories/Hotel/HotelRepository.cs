using GestHotelsDomain.Data;
using GestHotelsDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestHotelsDomain.Repositories.Hotel
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelDbContext _context;

        public HotelRepository(HotelDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Entities.Hotel> AddHotelAsync(Entities.Hotel hotel)
        {
            var result = _context.Hotel.Add(hotel);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteHotelAsync(int Id)
        {
            var filteredData = _context.Hotel.Where(x => x.Id == Id).FirstOrDefault();
            _context.Hotel.Remove(filteredData);
            return await _context.SaveChangesAsync();
        }

        public async Task<Entities.Hotel> GetHotelByIdAsync(int id)
        {
            return await _context.Hotel
                            .Include(h => h.Rooms)
                            .ThenInclude(r => r.PriceList)
                            .FirstOrDefaultAsync(h => h.Id == id);
                    }

        public async Task<List<Entities.Hotel>> GetHotelListAsync()
        {
            return await _context.Hotel
                            .Include(h => h.Rooms)
                            .ThenInclude(r => r.PriceList)
                            .ToListAsync();
        }

        public async Task<int> UpdateHotelAsync(Entities.Hotel hotel)
        {
            _context.Hotel.Update(hotel);
            return await _context.SaveChangesAsync();
        }
    }
}
