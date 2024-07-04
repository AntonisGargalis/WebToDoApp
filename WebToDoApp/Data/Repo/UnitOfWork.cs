using WebToDoApp.Data.Repo.IRepo;

namespace WebToDoApp.Data.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _db;
        public IToDoRepository ToDo { get; private set; }

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            ToDo = new ToDoRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
