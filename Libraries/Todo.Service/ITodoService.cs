using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.DAL;

namespace Todo.Service
{
    public interface ITodoService
    {
        List<TodoItem> GetAllItems();

        TodoItem GetTodoItemById(int id);

        List<TodoItem> GetTodayIsDeadLineItems();

        void CreateTodoItem(TodoItem model);
    }
}
