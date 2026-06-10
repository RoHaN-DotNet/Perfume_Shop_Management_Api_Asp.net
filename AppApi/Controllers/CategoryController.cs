using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        CategoryService Service;
        public CategoryController(CategoryService service)
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
        public IActionResult Create(CategoryDTO c)
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
        public IActionResult Update(CategoryDTO C)
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


        //
        [HttpGet("all/perfumes")]
        public IActionResult AllWithPerfumes()
        {
            var res= Service.GetWithPerfumes();
            return Ok(res);

        }
    }
}
