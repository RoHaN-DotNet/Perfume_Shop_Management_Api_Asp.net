using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        CustomerService Service;
        public CustomerController(CustomerService service)
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
        public IActionResult Create(CustomerDTO c)
        {
            var res = Service.Create(c);
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
        public IActionResult Update(CustomerDTO C)
        {
            var res = Service.Update(C);
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
        //others
        [HttpGet("phone")]
        public IActionResult FindByPhone(string phone)
        {
            var data = Service.FindByPhone(phone);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpGet("search")]
        public IActionResult SearchByName(string name)
        {
            return Ok(Service.SearchByName(name));
        }

        [HttpGet("with-orders")]
        public IActionResult CustomersWithOrders()
        {
            return Ok(Service.CustomersWithOrders());
        }

    }
}
