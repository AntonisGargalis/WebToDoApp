using Microsoft.EntityFrameworkCore;
using WebToDoApp.Models;

namespace WebToDoApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }

        public DbSet<ToDo> ToDos { get; set; }
    }
}
