using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GestHotelsDomain.Repositories.Price
{
    public interface IPriceRepository
    {
        public Task<List<Entities.Price>> GetPriceListAsync();
        public Task<Entities.Price> GetPriceByIdAsync(int Id);
        public Task<Entities.Price> AddPriceAsync(Entities.Price price);
        public Task<int> UpdatePriceAsync(Entities.Price price);
        public Task<int> DeletePriceAsync(int Id);
    }
}
