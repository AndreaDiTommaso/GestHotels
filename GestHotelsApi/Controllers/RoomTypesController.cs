﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestHotelsDomain.Entities;
using GestHotelsDomain.Data;

namespace GestHotelsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypesController : ControllerBase
    {
        private readonly HotelDbContext _context;

        public RoomTypesController(HotelDbContext context)
        {
            _context = context;
        }

        // GET: api/RoomTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomType>>> GetRoomType()
        {
          if (_context.RoomType == null)
          {
              return NotFound();
          }
            return await _context.RoomType.Include(r => r.PriceList).ToListAsync();
        }

        // GET: api/RoomTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomType>> GetRoomType(int id)
        {
          if (_context.RoomType == null)
          {
              return NotFound();
          }
            var roomType = await _context.RoomType
                .Include(r => r.PriceList)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (roomType == null)
            {
                return NotFound();
            }

            return roomType;
        }

        // PUT: api/RoomTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomType(int id, RoomType newRoomType)
        {
            var roomType = await _context.RoomType.FindAsync(id);
            if (roomType == null)
            {
                return NotFound();
            }
            roomType.Modify(newRoomType);

            _context.Entry(roomType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RoomTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomType>> PostRoomType(RoomType roomType)
        {
          if (_context.RoomType == null)
          {
              return Problem("Entity set 'HotelDbContext.RoomType'  is null.");
          }
            _context.RoomType.Add(roomType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomType", new { id = roomType.Id }, roomType);
        }

        // DELETE: api/RoomTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomType(int id)
        {
            if (_context.RoomType == null)
            {
                return NotFound();
            }
            var roomType = await _context.RoomType.FindAsync(id);
            if (roomType == null)
            {
                return NotFound();
            }

            _context.RoomType.Remove(roomType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomTypeExists(int id)
        {
            return (_context.RoomType?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        //private bool CheckCardinality(Price price)
        //{
            
        //        return (_context.RoomType?.Any(e => e.== id)).GetValueOrDefault();
        //}
    }
}
