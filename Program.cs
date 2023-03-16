using EmployeeManagement.DAL;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Services;

namespace EmployeeManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("http://localhost:4200");
                                      policy.AllowAnyHeader();
                                      policy.AllowAnyMethod();
                                  });
            });

            builder.Services.AddDbContext<EmployeeManagementContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Development"));
            });
            builder.Services.AddControllers();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();

            var app = builder.Build();

            app.UseCors(MyAllowSpecificOrigins);
            app.MapControllers();

            app.Run();
        }
    }
}