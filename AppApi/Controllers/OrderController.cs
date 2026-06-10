using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        OrderService Service;
        public OrderController(OrderService service)
        {
            this.Service = service;
        }
        [HttpGet("All")]
        public IActionResult All()
        {
            var data = Service.Get();
            return Ok(data);
        }
        [HttpGet("Id")]
        public IActionResult Get(int id)
        {
            var data = Service.Get();
            return Ok(data);
        }
        [HttpPost("Create")]
        public IActionResult Create(OrderDTO o)
        {
            var res = Service.Create(o);
            if (res == true)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }
        [HttpPost("Update")]
        public IActionResult Update(OrderDTO o)
        {
            var res = Service.Update(o);
            if (res == true)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }
        [HttpPost("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var res = Service.Delete(id);
            if (res == true)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }

        //other
        [HttpGet("by-customer/{customerId}")]
        public IActionResult OrdersByCustomer(int customerId)
        {
            return Ok(Service.GetByCustomer(customerId));
        }

        [HttpGet("{orderId}/items")]
        public IActionResult ItemsByOrder(int orderId)
        {
            return Ok(Service.GetItemsByOrder(orderId));
        }

        [HttpGet("sales-summary")]
        public IActionResult SalesSummary()
        {
            return Ok(Service.SalesSummary());
        }
        //placeorder
        [HttpPost("place")]
        public IActionResult Place([FromBody] OrderCreateDTO dto)
        {
            var res = Service.PlaceOrder(dto);
            return res ? Ok(new { message = "Order placed" }) : BadRequest(new { message = "Failed" });
        }

    }
}
