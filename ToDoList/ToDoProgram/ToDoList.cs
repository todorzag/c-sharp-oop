using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListProgram
{
    public class ToDoList
    {
        public List<ToDoItem> toDoList = new List<ToDoItem>();
        public record ToDoItem(string Content)
        {
            public int Id { get; set; }
            public bool IsCompleted { get; set; } = false;
        }
        private int idCounter = 1;

        public ToDoList()
        {
        }

        public void Add(string content)
        {
            if (content == null || content == " ")
            {
                throw new ArgumentNullException("Content cannot be null or empty");
            }

            toDoList.Add(new ToDoItem(content) with { Id = idCounter++ });
        }

        public void Complete(int id)
        {
            ToDoItem toDo = toDoList.Find(t => t.Id == id);
            toDo.IsCompleted = true;
        }
    }
}
