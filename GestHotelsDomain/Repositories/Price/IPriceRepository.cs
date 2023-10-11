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
        public Task<string> AddPriceAsync(Entities.Price price);
        public Task<string> UpdatePriceAsync(Entities.Price price);
        public Task<string> DeletePriceAsync(int Id);
    }
}
