using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalApp_ECommerce_DataAccessLayer.Data;
using FinalApp_ECommerce_DataAccessLayer.Models;
using FinalApp_Ecommerce_WebAPI.Infrastructure.Dto;

namespace FinalApp_Ecommerce_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyOrdersController : ControllerBase
    {
        private readonly ECommerceDbContext _context;

        public BuyOrdersController(ECommerceDbContext context)
        {
            _context = context;
        }

        // GET: api/BuyOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuyOrder>>> GetBuyOrders()
        {
            return await _context.BuyOrders.ToListAsync();
        }

        // GET: api/BuyOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BuyOrder>> GetBuyOrder(int id)
        {
            var buyOrder = await _context.BuyOrders.FindAsync(id);

            if (buyOrder == null)
            {
                return NotFound();
            }

            return buyOrder;
        }

        // PUT: api/BuyOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuyOrder(int id, BuyOrder buyOrder)
        {
            if (id != buyOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(buyOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuyOrderExists(id))
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

        // POST: api/BuyOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BuyOrder>> CreateBuyOrder([FromBody] BuyOrderDto buyOrderDto)
        {
           
            BuyOrder buyOrder = new BuyOrder
            {
                UserId = buyOrderDto.UserId,
                OrderDate = DateTime.Now,
                OrderNumber = Guid.NewGuid().ToString(),
                TotalAmount = buyOrderDto.BuyOrderItems.Sum(orderItem => orderItem.Price * orderItem.Quantity),
                /*
                OrderItems = buyOrderDto.BuyOrderItems.Select(x => new BuyOrderItem
                {
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                    Price = x.Price,

                }).ToList(),
                */
            };
               
            _context.BuyOrders.Add(buyOrder);
            await _context.SaveChangesAsync();

            foreach (var dtoBuyOrderItem in buyOrderDto.BuyOrderItems)
            {
                BuyOrderItem buyOrderItem = new BuyOrderItem
                {
                    BuyOrderId = buyOrder.Id,
                    ProductId = dtoBuyOrderItem.ProductId,
                    Quantity = dtoBuyOrderItem.Quantity,
                    Price = dtoBuyOrderItem.Price
                };

                _context.BuyOrderItems.Add(buyOrderItem);
            }

            await _context.SaveChangesAsync();

            return Ok(buyOrder);
            
            
        }

        // DELETE: api/BuyOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuyOrder(int id)
        {
            var buyOrder = await _context.BuyOrders.FindAsync(id);
            if (buyOrder == null)
            {
                return NotFound();
            }

            _context.BuyOrders.Remove(buyOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BuyOrderExists(int id)
        {
            return _context.BuyOrders.Any(e => e.Id == id);
        }
    }
}
