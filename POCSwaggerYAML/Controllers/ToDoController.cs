using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace POCSwaggerYAML.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : Controller
    {
        private static List<ToDo> todoList = new List<ToDo>();


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult GetTodoList()
        {
            if(todoList.Count == 0)
            {
                ToDo todo = new ToDo();
                todo.idToDo = 1;
                todo.task = "Todo number 1";
                todo.date = "18-05-2020";
                todo.time = "1200";
                todoList.Add(todo);
            }
            
            return Ok(todoList);
        }

        [HttpGet]
        [Route("{idToDo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetTodoList(int idToDo)
        {
            ToDo todoSearched = todoList.Find(todo => todo.idToDo == idToDo);
            if (todoSearched != null)
                return Ok(todoSearched);
            else
                return NotFound();            
        }

        [HttpPost]
        [Route("AddTodo")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult GetTodoList(ToDo todo)
        {
            todoList.Add(todo);
            return Ok();
        }
    }
}