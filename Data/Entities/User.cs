using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TODOLIST.Data.Entities
{
    public class User
    { 
        public int UserId { get; set; }
        public string Email { get; set; } = "";
        public string UserName { get; set; } = "";
        public string Address { get; set; } = "";
        public bool State {  get; set; }
        public ICollection<ToDo> ToDo { get; set; } = new List<ToDo>();
    }
}