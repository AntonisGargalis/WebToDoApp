using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebToDoApp.Areas.User.Models;

namespace WebToDoApp.Areas.User.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //Configure the relationship between ToDo and IdentityUser
            //modelBuilder.Entity<ToDo>()
            //.HasOne(t => t.User)
            //.WithMany()
            //.HasForeignKey(t => t.UserId)
            //.OnDelete(DeleteBehavior.Cascade);

        }
    }
}
