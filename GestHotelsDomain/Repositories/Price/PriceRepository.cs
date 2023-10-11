using GestHotelsDomain.Data;
using GestHotelsDomain.Entities;
using GestHotelsDomain.Services;
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

        public async Task<string> AddPriceAsync(Entities.Price price)
        {
            if (_context.Price == null)
            {
                return "Entity set 'HotelDbContext.Price' is null.";
            }
            var result = _context.Price.Add(price);
            HierarchyHelper hierarchyHelper = new HierarchyHelper(_context, price);
            if (hierarchyHelper.ValidatePrice())
            {
                await _context.SaveChangesAsync();
                return String.Format("New Price with id = {0} created succesfully",result.Entity.Id);
            }
            else
            {
                return "The price does not respect the hierarchy rules";
            }
        }

        public async Task<string> DeletePriceAsync(int Id)
        {
            var filteredData = _context.Price.Where(x => x.Id == Id).FirstOrDefault();
            if (filteredData == null)
            {
                return String.Format("Price with id = {0} not found", Id);

            }
            _context.Price.Remove(filteredData);
             await _context.SaveChangesAsync();
            return string.Format("Price with id = {0} deleted succesfully", Id);
        }

        public async Task<Entities.Price> GetPriceByIdAsync(int id)
        {
            return await _context.Price.FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<List<Entities.Price>> GetPriceListAsync()
        {
            return await _context.Price
                            .ToListAsync();
        }

        public async Task<string> UpdatePriceAsync(Entities.Price price)
        {
            //var price = await _context.Price.FindAsync(id);
            if (price == null)
            {
                return String.Format("Price with id = {0} not found",price.Id);
            }
            _context.Price.Update(price);
            HierarchyHelper hierarchyHelper = new HierarchyHelper(_context, price);
            if (hierarchyHelper.ValidatePrice())
            {
                await _context.SaveChangesAsync();
                return String.Format("Price with id = {0} updated succesfully", price.Id);

            }
            else
            {
                return "The price does not respect the hierarchy rules";
            }
            //price.Modify(newPrice);
            //_context.Entry(price).State = EntityState.Modified;

            //try
            //{
            //    HierarchyHelper hierarchyHelper = new HierarchyHelper(_context, price);
            //    if (hierarchyHelper.ValidatePrice())
            //    {
            //        await _context.SaveChangesAsync();
            //        return CreatedAtAction("GetPrice", new { id = price.Id }, price);
            //    }
            //    else
            //    {
            //        return Problem("The price does not respect the hierarchy rules");
            //    }
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!PriceExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
            //_context.Price.Update(price);
            //return await _context.SaveChangesAsync();
        }
    }
}
