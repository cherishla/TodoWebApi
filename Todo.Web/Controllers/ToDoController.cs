using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Todo.DAL;
using Todo.Service;

namespace Todo.Web.Controllers
{
    [RoutePrefix("api/todo")]
    public class ToDoController : ApiController
    {
        private readonly ITodoService _todoService;

        public ToDoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<TodoItem> GetAllItems()
        {
            return _todoService.GetAllItems();
        }

        [HttpGet]
        [Route("UnFinish")]
        public IEnumerable<TodoItem> GetUnFinishItems()
        {
            var items = _todoService.GetAllItems()
                                    .Where(x => !x.IsFinish);
            return items;
        }

        [HttpGet]
        [Route("TodayDeadLineItem")]
        public IEnumerable<TodoItem> GetTodayIsDeadLineItems()
        {
            var items = _todoService.GetTodayIsDeadLineItems();
            return items;
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateItem(TodoItem model)
        {
            if (string.IsNullOrWhiteSpace(model.Title))
            {
                return BadRequest("標題必須輸入");
            }

            _todoService.CreateTodoItem(model);

            return Ok();
        }
    }
}
