using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Northwind.DbModels.Model;
using Northwind.WebAPI.Repositorys;

namespace Northwind.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IRepository<Orders> _orderRepository;

        public OrdersController(IRepository<Orders> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<IEnumerable<Orders>> GetOrders()
        {
            return await _orderRepository.GetAllAsync();
        }


        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Orders>> GetOrders(int id)
        {
            var orders = await _orderRepository.FindAsync(id);

            if (orders == null)
            {
                return NotFound();
            }

            return orders;
        }

        //PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrders(int id, [FromBody]Orders orders)
        {
            if (id != orders.OrderId)
            {
                return BadRequest();
            }

            try
            {
                await _orderRepository.UpdateAsync(orders);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<Orders>> PostOrders(Orders orders)
        {
            await _orderRepository.InsertAsync(orders);
            return CreatedAtAction("GetOrders", new { id = orders.OrderId }, orders);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Orders>> DeleteOrders(int id)
        {
            var entity = await _orderRepository.FindAsync(id);
            await _orderRepository.DeleteAsync(id);

            return entity;
        }


    }
}
