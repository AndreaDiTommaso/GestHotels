
using Microsoft.AspNetCore.Mvc;
using GestHotelsDomain.Entities;
using MediatR;
using GestHotelsDomain.Queries.Price;
using GestHotelsDomain.Commands.Price;

namespace GestHotelsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PricesController( IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Price>>> GetPrice()
        {
            var price = await _mediator.Send(new GetPriceListQuery());
            return price;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Price>> GetPrice(int id)
        {
            var price = await _mediator.Send(new GetPriceByIdQuery() { Id = id });
            return price;
        }

        [HttpPut("{id}")]
        public async Task<string> PutPrice(int id, Price price)
        {
            var isPriceUpdated = await _mediator.Send(new UpdatePriceCommand(
            id,
            price.Cost,
            price.RoomTypeId,
            price.Date));
            return isPriceUpdated;
        }

        [HttpPost]
        public async Task<ActionResult<string>> PostPrice(Price newPrice)
        {

            var price = await _mediator.Send(new CreatePriceCommand(
                newPrice.Cost,
                newPrice.RoomTypeId,
                newPrice.Date));
            return price;


        }

        [HttpDelete("{id}")]
        public async Task<string> DeletePrice(int id)
        {
            return await _mediator.Send(new DeletePriceCommand() { Id = id });
        }
    }
}
