using System;
using System.Collections.Generic;
using System.Linq;
using Todo.DAL;

namespace Todo.Service
{
    public class TodoService : ITodoService
    {
        private readonly IToDoDbContext _db;

        public TodoService(IToDoDbContext db)
        {
            _db = db;
        }

        public List<TodoItem> GetAllItems()
        {
            return _db.TodoItems
                      .ToList();
        }

        public TodoItem GetTodoItemById(int id)
        {
            return _db.TodoItems
                      .FirstOrDefault(x => x.Id == id);
        }

        public List<TodoItem> GetTodayIsDeadLineItems()
        {
            return _db.TodoItems
                      .Where(x => x.DeadLineOn.Value.Date == DateTime.Now.Date)
                      .ToList();
        }

        public void CreateTodoItem(TodoItem model)
        {
            _db.TodoItems.Add(model);
            _db.SaveChanges();
        }
    }
}