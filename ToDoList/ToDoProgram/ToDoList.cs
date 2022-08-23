using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListProgram
{
    public class ToDoList
    {
        public int idCounter = 1;

        public List<ToDo> list;

        public ToDoList()
        {
            list = new List<ToDo>();
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

            list.Add(new ToDo(content) with { Id = idCounter++ });
        }

        public void Complete(int idCount)
        {
            ToDo toDo = list.Find(t => t.Id == idCount);
            toDo.IsCompleted = true;
        }
    }
}
