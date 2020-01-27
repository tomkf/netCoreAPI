using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using netCoreAPI.Services;

namespace netCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly TodoContext _context;
        public ToDoController(TodoContext context)
        {
            _context = context;
        }

        //when todo hit, this method fired
        [HttpGet]
        public IEnumerable<ToDo> GetAll()
        {
            return _context.ToDos.ToList();
        }

        [HttpGet("id", Name = "GetTodo")]
        {
            public IActionResult GetbyId(long id)
        {
            return new ObjectResult();
            {
                var item = _context.ToDos.FirstOrDefault(t => t.Id == id);
                if (item == null)
                {
                    return NotFound();
                }
                return new ObjectResult(item);
            }
        }
        }
    }
}