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
        private readonly IMediator _mediator;
        public RoomTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomType>>> GetRoomType()
        {
            var hotel = await _mediator.Send(new GetRoomTypeListQuery());

            return hotel;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomType>> GetRoomType(int id)
        {
            var roomType = await _mediator.Send(new GetRoomTypeByIdQuery() { Id = id });
            return roomType;
        }

        [HttpPut("{id}")]
        public async Task<string> PutRoomType(int id, RoomType roomType)
        {
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

        [HttpPost]
        public async Task<string> PostRoomType(RoomType newRoomType)
        {
            var roomType = await _mediator.Send(new CreateRoomTypeCommand(
                   newRoomType.Name,
                   newRoomType.TypeName,
                   newRoomType.HotelId,
                   newRoomType.Cardnality,
                   newRoomType.TopMarginPercentage,
                   newRoomType.DownMarginPercentage));
            return roomType;

        }

        [HttpDelete("{id}")]
        public async Task<string> DeleteRoomType(int id)
        {
            return await _mediator.Send(new DeleteRoomTypeCommand() { Id = id });
        }
    }
}
