using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediator.Orderings.Commands.Create;
using MultiShop.Order.Application.Features.Mediator.Orderings.Commands.Remove;
using MultiShop.Order.Application.Features.Mediator.Orderings.Commands.Update;
using MultiShop.Order.Application.Features.Mediator.Orderings.Queries.GetById;
using MultiShop.Order.Application.Features.Mediator.Orderings.Queries.GetList;

namespace MultiShop.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _mediator.Send(new GetOrderingListQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _mediator.Send(new GetOrderingByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderingCommand createOrderingCommand)
        {
            await _mediator.Send(createOrderingCommand);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateOrderingCommand updateOrderingCommand)
        {
            await _mediator.Send(updateOrderingCommand);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new RemoveOrderingCommand(id));
            return Ok();
        }
    }
}
