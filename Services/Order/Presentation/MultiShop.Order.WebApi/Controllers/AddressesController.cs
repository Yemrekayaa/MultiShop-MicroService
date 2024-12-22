using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediator.Adress.Commands.Create;
using MultiShop.Order.Application.Features.Mediator.Adress.Commands.Remove;
using MultiShop.Order.Application.Features.Mediator.Adress.Commands.Update;
using MultiShop.Order.Application.Features.Mediator.Adress.Queries.GetAddressById;
using MultiShop.Order.Application.Features.Mediator.Adress.Queries.GetAddressList;

namespace MultiShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _mediator.Send(new GetAddressListQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _mediator.Send(new GetAddressByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAddressCommand createAddressCommand)
        {
            await _mediator.Send(createAddressCommand);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAddressCommand updateAddressCommand)
        {
            await _mediator.Send(updateAddressCommand);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new RemoveAddressCommand(id));
            return Ok();
        }
    }
}
