using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListProgram
{
    public class ToDoList
    {
        private int idCounter = 1;
        public List<ToDo> toDoList = new List<ToDo>();

        public ToDoList()
        {
        }

        public record ToDo(string Content)
        {
            public int Id { get; set; }
            public bool IsCompleted { get; set; } = false;
        }

        public void Add(string content)
        {
            if (content == null || content == " ")
            {
                throw new ArgumentNullException("Content cannot be null or empty");
            }

            toDoList.Add(new ToDo (content) with { Id = idCounter++ });
        }

        public void Complete(int id)
        {
            ToDo toDo = toDoList.Find(t => t.Id == id);
            toDo.IsCompleted = true;
        }
    }
}
