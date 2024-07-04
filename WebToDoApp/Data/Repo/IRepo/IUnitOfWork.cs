namespace WebToDoApp.Data.Repo.IRepo
{
    public interface IUnitOfWork
    {
        IToDoRepository ToDo { get; }
        void Save();
    }
}
