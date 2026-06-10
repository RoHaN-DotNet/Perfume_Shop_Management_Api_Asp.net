using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfumeController : ControllerBase
    {
        PerfumeService Service;
        public PerfumeController(PerfumeService service)
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
        public IActionResult Create(PerfumeDTO p)
        {
            var res = Service.Create(p);
            if (res == true)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }
        
        [HttpPut("Update")]
        public IActionResult Update(PerfumeDTO P)
        {
            var res = Service.Update(P);
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
        [HttpGet("search")]
        public IActionResult Search(string name)
        {
            return Ok(Service.SearchByName(name));
        }

        [HttpGet("price")]
        public IActionResult FilterByPrice(decimal min, decimal max)
        {
            return Ok(Service.FilterByPrice(min, max));
        }

        [HttpGet("by-category/{categoryId}")]
        public IActionResult ByCategory(int categoryId)
        {
            return Ok(Service.GetByCategory(categoryId));
        }

        [HttpGet("top-expensive")]
        public IActionResult TopExpensive(int top = 5)
        {
            return Ok(Service.TopExpensive(top));
        }
    }
}
