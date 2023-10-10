using GestHotelsDomain.Data;
using GestHotelsDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestHotelsDomain.Repositories.Price
{
    public class PriceRepository : IPriceRepository
    {
        private readonly HotelDbContext _context;

        public PriceRepository(HotelDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Entities.Price> AddPriceAsync(Entities.Price price)
        {
            var result = _context.Price.Add(price);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeletePriceAsync(int Id)
        {
            var filteredData = _context.Price.Where(x => x.Id == Id).FirstOrDefault();
            _context.Price.Remove(filteredData);
            return await _context.SaveChangesAsync();
        }

        public async Task<Entities.Price> GetPriceByIdAsync(int id)
        {
            return await _context.Price
                            .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<List<Entities.Price>> GetPriceListAsync()
        {
            return await _context.Price
                            .ToListAsync();
        }

        public async Task<int> UpdatePriceAsync(Entities.Price price)
        {
            _context.Price.Update(price);
            return await _context.SaveChangesAsync();
        }
    }
}
