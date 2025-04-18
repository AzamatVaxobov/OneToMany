
using OneToMany.Repository.CarRepository;
using OneToMany.Repository.LogRepository;
using OneToMany.Repository.PersonRepository;
using OneToMany.Server.Configurations;
using OneToMany.Server.Middleware;
using OneToMany.Service.CarService;
using OneToMany.Service.PersonService;
using Serilog;
using Serilog.Sinks.Telegram;



namespace OneToMany.Server;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        Log.Logger = new LoggerConfiguration()
       .MinimumLevel.Information()
       .WriteTo.Telegram
        (
            botToken: "8082585188:AAHXfZmSeJz2ih8WrpVXpG4Xv-NLFxV8i2k",
            chatId: "6448388108",
            restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information
        )
        .CreateLogger();
        try
        {
            Log.Information("Dastur ishga tushdi");
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Db configuration
            builder.ConfigureDatabase();


            // Register ILogRepository with its implementation LogRepository as scoped
            builder.Services.AddScoped<ILogRepository, LogRepository>();

            // Dependecy injection
            builder.Services.AddScoped<IPersonRepository, PersonRepository>();
            builder.Services.AddScoped<IPersonService, PersonService>();
            builder.Services.AddScoped<ICarRepository, CarRepository>();
            builder.Services.AddScoped<ICarService, CarService>();

            builder.Host.UseSerilog();

            var app = builder.Build();

            app.UseMiddleware<RequestLoggingMiddleware>();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
        catch (Exception ex)
        {
            Log.Error(ex,"An error occurred during application startup.");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
