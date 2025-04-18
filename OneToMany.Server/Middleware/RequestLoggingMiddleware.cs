using OneToMany.DataAccess;
using OneToMany.DataAccess.Entites;
using OneToMany.Repository.LogRepository;

namespace OneToMany.Server.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _serviceProvider;

        public RequestLoggingMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
        {
            _next = next;
            _serviceProvider = serviceProvider;
        }

        public Task Invoke(HttpContext context)
        {
            // Create a new service scope for each request
            using (var scope = _serviceProvider.CreateScope())
            {
                // Resolve the scoped ILogRepository
                var logRepository = scope.ServiceProvider.GetRequiredService<ILogRepository>();

                // Create the log entry
                var log = new Logs
                {
                    RequestMethod = context.Request.Method,
                    RequestPath = context.Request.Path,
                    Timestamp = DateTime.UtcNow
                };

                // Save log (this is synchronous, but returns a Task)
                logRepository.SaveLog(log);
            }

            // Continue to the next middleware
            return _next(context);
        }
    }

}



