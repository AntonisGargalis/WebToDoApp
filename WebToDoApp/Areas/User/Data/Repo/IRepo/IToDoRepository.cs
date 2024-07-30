using WebToDoApp.Areas.User.Models;

namespace WebToDoApp.Areas.User.Data.Repo.IRepo
{
    public interface IToDoRepository : IRepository<ToDo>
    {
        void Update(ToDo obj);
    }
}
