using WebToDoApp.Models;

namespace WebToDoApp.Data.Repo.IRepo
{
    public interface IToDoRepository : IRepository<ToDo>
    {
        void Update(ToDo obj);
    }
}
