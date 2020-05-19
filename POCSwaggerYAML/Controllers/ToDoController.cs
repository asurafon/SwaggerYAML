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

        /// <summary>
        /// Gets all TodoItems.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Todo
        ///
        /// </remarks>
        /// <returns>A list of all the todo items</returns>
        /// <response code="200">Returns the list of all todos</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult GetTodoList()
        {
            if (todoList.Count == 0)
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

        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Todo/{idToDo}
        ///
        /// </remarks>
        /// <param name="idToDo">The todo id</param>
        /// <param name="transactionId">The transaction id</param>
        /// <returns>The todo item</returns>
        /// <response code="200">Returns the newly created item</response>
        /// <response code="400">if the item doesn't exist</response>  
        [HttpGet]
        [Route("{idToDo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetTodoList(int idToDo, [FromQuery(Name = "transactionId")] string transactionId)
        {
            ToDo todoSearched = todoList.Find(todo => todo.idToDo == idToDo);
            if (todoSearched != null)
                return Ok(todoSearched);
            else
                return NotFound();
        }

        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo/AddTodo
        ///     {
        ///         "idToDo": 1,
        ///          "task": "Todo number 1",
        ///          "date": "18-05-2020",
        ///          "time": "1200"
        ///     }
        /// 
        /// </remarks>
        /// <param name="todo">The todo item to add</param>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="201">Returns the newly created item</response>
        [HttpPost]
        [Route("AddTodo")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult GetTodoList(ToDo todo)
        {
            todoList.Add(todo);
            return Created("AddTodo", todo);
        }
    }
}