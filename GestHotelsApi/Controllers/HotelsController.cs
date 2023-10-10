using GestHotelsDomain.Commands.Hotel;
using GestHotelsDomain.Data;
using GestHotelsDomain.Entities;
using GestHotelsDomain.Queries.Hotel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestHotelsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly HotelDbContext _context;
        private readonly IMediator _mediator;
        public HotelsController(HotelDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        // GET: api/People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetPerson()
        {
            //if (_context.Hotel == null)
            //{
            //    return NotFound();
            //}
            //return await _context.Hotel
            //    .Include(h =>h.Rooms)
            //    .ThenInclude(r =>r.PriceList)
            //    .ToListAsync();
            var hotel = await _mediator.Send(new GetPriceListQuery());

            return hotel;
        }

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetPerson(int id)
        {
            //if (_context.Hotel == null)
            //{
            //    return NotFound();
            //}
            //var hotel = await _context.Hotel
            //    .Include(h => h.Rooms)
            //    .ThenInclude(r => r.PriceList)
            //    .FirstOrDefaultAsync(h => h.Id == id);

            //if (hotel == null)
            //{
            //    return NotFound();
            //}

            //return hotel;
            var hotel = await _mediator.Send(new GetPriceByIdQuery() { Id = id });

            return hotel;
        }

        // PUT: api/People/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<int> PutPerson(int id, Hotel hotel)
        {
            //var hotel = await _context.Hotel.FindAsync(id);
            //if (hotel == null)
            //{
            //    return NotFound();
            //}
            //hotel.Modify(newHotel);

            //_context.Entry(hotel).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!PersonExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
            var isHotelUpdated = await _mediator.Send(new UpdateHotelCommand(
              id,
              hotel.Name,
              hotel.Address,
              hotel.Stars));
            return isHotelUpdated;
        }

        // POST: api/People
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostPerson(Hotel newHotel)
        {
            //if (_context.Hotel == null)
            //{
            //    return Problem("Entity set 'HotelDbContext.Hotel'  is null.");
            //}
            //_context.Hotel.Add(hotel);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);
            var hotel = await _mediator.Send(new CreateHotelCommand(
                newHotel.Name,
                newHotel.Address,
                newHotel.Stars));
            return hotel;
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<int> DeletePerson(int id)
        {
            //if (_context.Hotel == null)
            //{
            //    return NotFound();
            //}
            //var hotel = await _context.Hotel.FindAsync(id);
            //if (hotel == null)
            //{
            //    return NotFound();
            //}

            //_context.Hotel.Remove(hotel);
            //await _context.SaveChangesAsync();

            //return NoContent();
            return await _mediator.Send(new DeletePriceCommand() { Id = id });
        }

        //private bool PersonExists(int id)
        //{
        //    return (_context.Hotel?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
