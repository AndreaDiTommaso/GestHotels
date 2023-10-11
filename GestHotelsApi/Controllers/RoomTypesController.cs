using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestHotelsDomain.Entities;
using GestHotelsDomain.Data;
using MediatR;
using GestHotelsDomain.Queries.RoomType;
using GestHotelsDomain.Commands.RoomType;

namespace GestHotelsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypesController : ControllerBase
    {
        private readonly HotelDbContext _context;
        private readonly IMediator _mediator;
        public RoomTypesController(HotelDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        // GET: api/RoomTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomType>>> GetRoomType()
        {
            //if (_context.RoomType == null)
            //{
            //    return NotFound();
            //}
            //  return await _context.RoomType.Include(r => r.PriceList).ToListAsync();
            var hotel = await _mediator.Send(new GetRoomTypeListQuery());

            return hotel;
        }

        // GET: api/RoomTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomType>> GetRoomType(int id)
        {
            //if (_context.RoomType == null)
            //{
            //    return NotFound();
            //}
            //  var roomType = await _context.RoomType
            //      .Include(r => r.PriceList)
            //      .FirstOrDefaultAsync(r => r.Id == id);

            //  if (roomType == null)
            //  {
            //      return NotFound();
            //  }

            //  return roomType;
            var roomType = await _mediator.Send(new GetRoomTypeByIdQuery() { Id = id });

            return roomType;
        }

        // PUT: api/RoomTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<int> PutRoomType(int id, RoomType roomType)
        {
            //var roomType = await _context.RoomType.FindAsync(id);
            //if (roomType == null)
            //{
            //    return NotFound();
            //}
            //roomType.Modify(newRoomType);

            //_context.Entry(roomType).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!RoomTypeExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
            var isRoomTypeUpdated = await _mediator.Send(new UpdateRoomTypeCommand(
           id,
           roomType.Name,
           roomType.TypeName,
           roomType.HotelId,
           roomType.Cardnality,
           roomType.TopMarginPercentage,
           roomType.DownMarginPercentage
           ));
            return isRoomTypeUpdated;
        }

        // POST: api/RoomTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomType>> PostRoomType(RoomType newRoomType)
        {
            //if (_context.RoomType == null)
            //{
            //    return Problem("Entity set 'HotelDbContext.RoomType'  is null.");
            //}
            //  _context.RoomType.Add(roomType);
            //  await _context.SaveChangesAsync();

            //  return CreatedAtAction("GetRoomType", new { id = roomType.Id }, roomType);
            var roomType = await _mediator.Send(new CreateRoomTypeCommand(
                   newRoomType.Name,
                   newRoomType.TypeName,
                   newRoomType.HotelId,
                   newRoomType.Cardnality,
                   newRoomType.TopMarginPercentage,
                   newRoomType.DownMarginPercentage));
            return roomType;

        }

        // DELETE: api/RoomTypes/5
        [HttpDelete("{id}")]
        public async Task<int> DeleteRoomType(int id)
        {
            //if (_context.RoomType == null)
            //{
            //    return NotFound();
            //}
            //var roomType = await _context.RoomType.FindAsync(id);
            //if (roomType == null)
            //{
            //    return NotFound();
            //}

            //_context.RoomType.Remove(roomType);
            //await _context.SaveChangesAsync();

            //return NoContent();
            return await _mediator.Send(new DeleteRoomTypeCommand() { Id = id });

        }

        //private bool RoomTypeExists(int id)
        //{
        //    return (_context.RoomType?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
        //private bool CheckCardinality(Price price)
        //{

        //        return (_context.RoomType?.Any(e => e.== id)).GetValueOrDefault();
        //}
    }
}
