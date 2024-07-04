using System.ComponentModel.DataAnnotations;

namespace WebToDoApp.Models
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public DateOnly DatePick { get; set; }
        public TimeOnly TimePick { get; set; }

    }
}
