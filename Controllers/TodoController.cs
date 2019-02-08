using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using net_core_todoapi.Models;

namespace net_core_todoapi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TodoController : ControllerBase
  {
    private readonly TodoContext _context;

    public TodoController(TodoContext context)
    {
      _context = context;

      if (_context.TodoItems.Count() == 0)
      {
        // Create a new TodoItem if collection is empty,
        // which means you can't delete all TodoItems.
        _context.TodoItems.Add(new TodoItem { Name = "Item1" });
        _context.SaveChanges();
      }
    }
  }
}