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
        public Task<Entities.RoomType> AddRoomTypeAsync(Entities.RoomType roomType);
        public Task<int> UpdateRoomTypeAsync(Entities.RoomType roomType);
        public Task<int> DeleteRoomTypeAsync(int Id);
    }
}
