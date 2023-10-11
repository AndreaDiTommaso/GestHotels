using GestHotelsDomain.Commands.Hotel;
using GestHotelsDomain.Entities;
using GestHotelsDomain.Queries.Hotel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestHotelsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public HotelsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetPerson()
        {
            var hotel = await _mediator.Send(new GetHotelListQuery());
            return hotel;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetPerson(int id)
        {
            var hotel = await _mediator.Send(new GetHotelByIdQuery() { Id = id });
            return hotel;
        }

        [HttpPut("{id}")]
        public async Task<string> PutPerson(int id, Hotel hotel)
        {
            var isHotelUpdated = await _mediator.Send(new UpdateHotelCommand(
              id,
              hotel.Name,
              hotel.Address,
              hotel.Stars));
            return isHotelUpdated;
        }

        [HttpPost]
        public async Task<string> PostPerson(Hotel newHotel)
        {
            var hotel = await _mediator.Send(new CreateHotelCommand(
             newHotel.Name,
             newHotel.Address,
             newHotel.Stars));
            return hotel;
        }

        [HttpDelete("{id}")]
        public async Task<string> DeletePerson(int id)
        {
            return await _mediator.Send(new DeleteHotelCommand() { Id = id });
        }

    }
}
