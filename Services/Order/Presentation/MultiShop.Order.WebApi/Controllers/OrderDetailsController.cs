using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediator.OrderDetails.Commands.Create;
using MultiShop.Order.Application.Features.Mediator.OrderDetails.Commands.Remove;
using MultiShop.Order.Application.Features.Mediator.OrderDetails.Commands.Update;
using MultiShop.Order.Application.Features.Mediator.OrderDetails.Queries.GetById;
using MultiShop.Order.Application.Features.Mediator.OrderDetails.Queries.GetList;

namespace MultiShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _mediator.Send(new GetOrderDetailListQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _mediator.Send(new GetOrderDetailByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderDetailCommand createOrderDetailCommand)
        {
            await _mediator.Send(createOrderDetailCommand);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateOrderDetailCommand updateOrderDetailCommand)
        {
            await _mediator.Send(updateOrderDetailCommand);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new RemoveOrderDetailCommand(id));
            return Ok();
        }
    }
}
