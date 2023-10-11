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

        public async Task<string> AddHotelAsync(Entities.Hotel hotel)
        {
            var result = _context.Hotel.Add(hotel);
            await _context.SaveChangesAsync();
            return String.Format("New Hotel with id = {0} created succesfully", result.Entity.Id);

        }

        public async Task<string> DeleteHotelAsync(int Id)
        {
            var filteredData = _context.Hotel.Where(x => x.Id == Id).FirstOrDefault();
            _context.Hotel.Remove(filteredData);
             await _context.SaveChangesAsync();
            return string.Format("Hotel with id = {0} deleted succesfully", Id);

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

        public async Task<string> UpdateHotelAsync(Entities.Hotel hotel)
        {
            _context.Hotel.Update(hotel);
            await _context.SaveChangesAsync();
            return String.Format("Hotel with id = {0} updated succesfully", hotel.Id);

        }
    }
}
