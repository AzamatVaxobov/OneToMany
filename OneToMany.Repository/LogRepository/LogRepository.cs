using OneToMany.DataAccess.Entites;
using OneToMany.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToMany.Repository.LogRepository
{
    // File: Repo/LogRepository.cs
    public class LogRepository : ILogRepository
    {
        private readonly MainContext _context;

        public LogRepository(MainContext context)
        {
            _context = context;
        }

        // Use Task but without async/await
        public Task SaveLog(Logs log)
        {
            _context.Logs.Add(log);
            _context.SaveChanges(); // Synchronous save
            return Task.CompletedTask; // Return a completed task to indicate success
        }
    }

    // Interface for LogRepository
  


}
