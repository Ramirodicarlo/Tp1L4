using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TODOLIST.Data.Entities
{
    public class ToDo
    {
        public int ToDoId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool State { get; set; }
        [ForeignKey("UserID")]
        public int UserID { get; set; }
    }

    }
