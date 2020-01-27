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


        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(long id)
        {
            var item = _context.ToDos.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody]ToDo todo)
        {
            if (todo.Description == null || todo.Description == "")
            {
                return BadRequest();
            }
            _context.ToDos.Add(todo);
            _context.SaveChanges();
            return new ObjectResult(todo);
        }

        [HttpPut]
        [Route("MyEdit")] // Custom route
        public IActionResult GetByParams([FromBody]ToDo todo)
        {
            var item = _context.ToDos.Where(t => t.Id == todo.Id).FirstOrDefault();
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                item.IsComplete = todo.IsComplete;
                _context.SaveChanges();
            }
            return new ObjectResult(item);
        }

    }
}