using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestHotelsDomain.Entities;
using GestHotelsApi.Servicies;
using GestHotelsDomain.Data;
using MediatR;
using GestHotelsDomain.Queries.Price;
using GestHotelsDomain.Commands.Price;

namespace GestHotelsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricesController : ControllerBase
    {
        private readonly HotelDbContext _context;
        private readonly IMediator _mediator;
        public PricesController(HotelDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        // GET: api/Prices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Price>>> GetPrice()
        {
          //if (_context.Price == null)
          //{
          //    return NotFound();
          //}
          //  return await _context.Price.ToListAsync();
            var price = await _mediator.Send(new GetPriceListQuery());

            return price;
        }

        // GET: api/Prices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Price>> GetPrice(int id)
        {
            //if (_context.Price == null)
            //{
            //    return NotFound();
            //}
            //  var price = await _context.Price.FindAsync(id);

            //  if (price == null)
            //  {
            //      return NotFound();
            //  }

            //  return price;
            var price = await _mediator.Send(new GetPriceByIdQuery() { Id = id });

            return price;
        }
        

        // PUT: api/Prices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<int> PutPrice(int id, Price price)
        {

            //var price = await _context.Price.FindAsync(id);
            //if (price == null)
            //{
            //    return NotFound();
            //}
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

            //return NoContent();
            var isPriceUpdated = await _mediator.Send(new UpdatePriceCommand(
            id,
            price.Cost,
             price.RoomTypeId,
            price.Date
           ));
            return isPriceUpdated;
        }

        // POST: api/Prices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Price>> PostPrice(Price newPrice)
        {
            //if (_context.Price == null)
            //{
            //    return Problem("Entity set 'HotelDbContext.Price'  is null.");
            //}
            //  _context.Price.Add(price);
            //  HierarchyHelper hierarchyHelper = new HierarchyHelper(_context,price);
            //if (hierarchyHelper.ValidatePrice())
            //  {
            //      await _context.SaveChangesAsync();
            //      return CreatedAtAction("GetPrice", new { id = price.Id }, price);
            //  }
            //else
            //  {
            //      return Problem("The price does not respect the hierarchy rules");
            //  } 
            var price = await _mediator.Send(new CreatePriceCommand(
                newPrice.Cost,
                newPrice.RoomTypeId,
                newPrice.Date));
            return price;


        }

        // DELETE: api/Prices/5
        [HttpDelete("{id}")]
        public async Task<int> DeletePrice(int id)
        {
            //if (_context.Price == null)
            //{
            //    return NotFound();
            //}
            //var price = await _context.Price.FindAsync(id);
            //if (price == null)
            //{
            //    return NotFound();
            //}

            //_context.Price.Remove(price);
            //await _context.SaveChangesAsync();

            //return NoContent();
            return await _mediator.Send(new DeletePriceCommand() { Id = id });

        }

        //private bool PriceExists(int id)
        //{
        //    return (_context.Price?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
        //private bool ValidatePrice(Price price)
        //{
        //    RoomType roomType = _context.RoomType.FirstOrDefault(r => r.Id == price.RoomTypeId);
        //    Hotel hotel = _context.Hotel
        //        .Include(h => h.Rooms)
        //        .ThenInclude(r => r.PriceList)
        //        .FirstOrDefault(h => h.Id == roomType.HotelId);

        //    int nextCardinality = 0;
        //    List<int> listLowerCardinality = hotel.Rooms.Select(r => r.Cardnality).Where(c => c > roomType.Cardnality).ToList();
        //    if (listLowerCardinality!=null)
        //    {
        //        nextCardinality= listLowerCardinality.Min();
        //    }
        //    int prevCardinality = 0;
        //    List<int> listUpperCardinality = hotel.Rooms.Select(r => r.Cardnality).Where(c => c < roomType.Cardnality).ToList();
        //    if (listUpperCardinality != null)
        //    {
        //        prevCardinality = listUpperCardinality.Max();
        //    }
        //    decimal nextPrice = 0;
        //    decimal prevPrice = 0;

        //    foreach (RoomType room in hotel.Rooms)
        //    {
        //        if(room.Cardnality == nextCardinality && room.PriceList != null)
        //        {
        //            decimal x = room.PriceList.FirstOrDefault(p => p.Date == price.Date).Cost;
        //            if(nextPrice == 0)
        //            {
        //                nextPrice = x;
        //            }
        //            else
        //            {
        //                if (x < nextPrice)
        //                { nextPrice = x; }
        //            }

        //        }
        //        if (room.Cardnality == prevCardinality && room.PriceList != null)
        //        {
        //            decimal y = room.PriceList.FirstOrDefault(p => p.Date == price.Date).Cost;
        //            if (y > prevPrice) { prevPrice = y; }
        //        }
        //    }
        //    decimal upperBound = 0;
        //    if (nextPrice != 0)
        //    {
        //        upperBound = nextPrice - (price.Cost * roomType.UpperBound) / 100;
        //    }
        //    decimal lowerBound = 0;
        //    if (prevPrice != 0)
        //    {
        //        lowerBound = prevPrice + (prevPrice * roomType.LowerBound) / 100;
        //    }
        //    if((price.Cost> lowerBound || lowerBound==0) && (price.Cost< upperBound || upperBound==0))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}
    }
}
