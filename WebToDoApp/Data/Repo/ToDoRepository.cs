using WebToDoApp.Data.Repo.IRepo;
using WebToDoApp.Models;

namespace WebToDoApp.Data.Repo
{
    public class ToDoRepository : Repository<ToDo>, IToDoRepository
    {
        private AppDbContext _db;
        public ToDoRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(ToDo obj)
        {
            _db.ToDos.Update(obj);
        }
    }
}
