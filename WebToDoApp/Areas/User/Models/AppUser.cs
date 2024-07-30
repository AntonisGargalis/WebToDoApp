using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;


namespace WebToDoApp.Areas.User.Models
{
    public class AppUser : IdentityUser
    {

        [Required]
        public string Name { get; set; }
        public string City { get; set; }
    }
}
