using CleanArchMvc.Infra.Ioc;

namespace CleanArchMvc.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer(); // Register endpoints explorer
            builder.Services.AddSwaggerGen(); // Register Swagger services
            builder.Services.AddInfrastrutureAPI(builder.Configuration); // Register infrastructure services
            builder.Services.AddInfrastructureJWT(builder.Configuration); // Register JWT services

            var app = builder.Build();

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
    }
}
