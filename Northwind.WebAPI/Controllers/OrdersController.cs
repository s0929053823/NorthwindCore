using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Northwind.DbModels.Model;
using Northwind.WebAPI.Commnads;
using Northwind.WebAPI.Repositorys;

namespace Northwind.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        //     private readonly IRepository<Orders> _orderRepository;
        private IMediator _mediator;


        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
            //_orderRepository = orderRepository;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<IEnumerable<Orders>> GetOrders()
        {
            return await _mediator.Send(new GetOrderListQuery());
        }


        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Orders>> GetOrders(int id)
        {
            var order = await _mediator.Send(new GetOrderDetailQuery { Id = id });

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        //PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrders(int id, [FromBody]UpdateOrderCommand command)
        {
            if (id != command.OrderId)
            {
                return BadRequest();
            }

            try
            {

                await _mediator.Send(command);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<Orders>> PostOrders([FromBody]CreateOrderCommand command)
        {

            // await _orderRepository.InsertAsync(orders);
            await _mediator.Send(command);
            return NoContent();
            //  return CreatedAtAction("GetOrders", new { id = newOrderId });
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Orders>> DeleteOrders(int id)
        {
            var order = await _mediator.Send(new GetOrderDetailQuery { Id = id });

            await _mediator.Send(new DeleteOrderCommand { Id = id });

            return order;
        }


    }
}
