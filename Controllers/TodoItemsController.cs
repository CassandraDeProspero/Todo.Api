using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Todo.Api.Models;
using Todo.Api.Services;

namespace Todo.Api.Controllers
{
    [ApiController]
    [Route("api/todos")]
    public class TodoItemsController : ControllerBase
    {
          private ITodoRepository repository;
        public TodoItemsController(ITodoRepository todoRepository)
        {
            repository = todoRepository ??
                throw new ArgumentNullException(nameof(todoRepository));
        }
        [HttpGet]
        public IActionResult GetTodos()
        {
            TodoItem todoItem = new TodoItem { Id = 2, Action = "Thing two.", IsDone = false };
            var result = repository.GetAllTodoItems();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        private IActionResult ok(List<TodoItem> result)
        {
            throw new NotImplementedException();
        }
      
    }
}