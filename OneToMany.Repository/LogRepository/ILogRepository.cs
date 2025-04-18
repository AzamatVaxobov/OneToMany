using OneToMany.DataAccess.Entites;

namespace OneToMany.Repository.LogRepository
{
    public interface ILogRepository
    {
        Task SaveLog(Logs log); // Use Task but without async
    }
}