using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        OrderItemService Service;
        public OrderItemController(OrderItemService service)
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
        public IActionResult Create(OrderItemDTO oi)
        {
            var res = Service.Create(oi);
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
        public IActionResult Update(OrderItemDTO oi)
        {
            var res = Service.Update(oi);
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
    }
}
