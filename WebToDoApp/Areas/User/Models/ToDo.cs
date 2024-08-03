using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebToDoApp.Areas.User.Models
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
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        [ValidateNever]
        public virtual IdentityUser User { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
    }
}
