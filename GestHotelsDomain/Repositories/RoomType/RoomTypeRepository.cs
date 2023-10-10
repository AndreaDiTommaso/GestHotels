using GestHotelsDomain.Data;
using GestHotelsDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestHotelsDomain.Repositories.RoomType
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly HotelDbContext _context;

        public RoomTypeRepository(HotelDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Entities.RoomType> AddRoomTypeAsync(Entities.RoomType roomType)
        {
            var result = _context.RoomType.Add(roomType);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteRoomTypeAsync(int Id)
        {
            var filteredData = _context.RoomType.Where(x => x.Id == Id).FirstOrDefault();
            _context.RoomType.Remove(filteredData);
            return await _context.SaveChangesAsync();
        }

        public async Task<Entities.RoomType> GetRoomTypeByIdAsync(int id)
        {
            return await _context.RoomType
                            .Include(r => r.PriceList)
                            .FirstOrDefaultAsync(h => h.Id == id);
                    }

        public async Task<List<Entities.RoomType>> GetRoomTypeListAsync()
        {
            return await _context.RoomType
                            .Include(r => r.PriceList)
                            .ToListAsync();
        }

        public async Task<int> UpdateRoomTypeAsync(Entities.RoomType roomType)
        {
            _context.RoomType.Update(roomType);
            return await _context.SaveChangesAsync();
        }
    }
}
