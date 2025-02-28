using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrdersSonae.Business.Commands;
using OrdersSonae.Business.DTOs;
using OrdersSonae.Business.Queries;
using OrdersSonae.Business.Services;
using OrdersSonae.Domain.Emums;

namespace OrdersSonae.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly InMemoryDataStore _dataStore;

        public OrderController(IMediator mediator, InMemoryDataStore dataStore)
        {
            _mediator = mediator;
            _dataStore = dataStore;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateOrder(CreateOrderCommand command)
        {
            try
            {
                var orderId = await _mediator.Send(command);
                return Ok(orderId);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrder(Guid id)
        {
            try
            {
                var order = await _mediator.Send(new GetOrderQuery(id));
                return Ok(order);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}/update-status")]
        public IActionResult UpdateOrderStatus(Guid id, [FromBody] OrderStatus status)
        {
            var order = _dataStore.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
                return NotFound("Order not found");

            order.UpdateStatus(status);

            return Ok(new { Message = "Order status updated successfully" });
        }
    }
}