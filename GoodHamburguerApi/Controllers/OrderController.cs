using Microsoft.AspNetCore.Mvc;
using Rg_Domain.Dto;
using Rg_Domain.Models;
using Rg_Service.Interfaces;

namespace GoodHamburguerApi.Controllers
{
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService _orderService)
        {
            orderService = _orderService;
        }

        [HttpGet()]
        [Route("GetAllOrders")]
        public IEnumerable<GetOrderDto> GetAllOrders()
        {
            return orderService.GetAllOrders();
        }

        [HttpPost()]
        [Route("CreateOrder")]
        public IActionResult CreateOrder([FromBodyAttribute] CreateOrderDto entity)
        {
            try
            {
                var order = orderService.CreateOrder(entity);
                return Ok(order);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut()]
        [Route("UpdateOrder")]
        public IActionResult UpdateOrder(Order entity)
        {
            try
            {
                orderService.Update(entity);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete()]
        [Route("DeleteOrder")]
        public IActionResult DeleteOrder([FromBodyAttribute] int orderId)
        {
            try
            {
                orderService.Delete(orderId);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}