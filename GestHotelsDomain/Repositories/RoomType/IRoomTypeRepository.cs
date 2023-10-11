using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GestHotelsDomain.Repositories.RoomType
{
    public interface IRoomTypeRepository
    {
        public Task<List<Entities.RoomType>> GetRoomTypeListAsync();
        public Task<Entities.RoomType> GetRoomTypeByIdAsync(int Id);
        public Task<string> AddRoomTypeAsync(Entities.RoomType roomType);
        public Task<string> UpdateRoomTypeAsync(Entities.RoomType roomType);
        public Task<string> DeleteRoomTypeAsync(int Id);
    }
}
