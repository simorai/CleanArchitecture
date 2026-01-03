using CleanArchMvc.Infra.Ioc;

namespace CleanArchMvc.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer(); // Register endpoints explorer
            builder.Services.AddInfrastrutureAPI(builder.Configuration); // Register infrastructure services through extension method
            builder.Services.AddInfrastructureJWT(builder.Configuration); // Register JWT services through extension method
            builder.Services.AddInfrastructureSwagger(); // Register Swagger services through extension method

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStatusCodePages(); // Enable status code pages for better error handling
            // correct order of middleware to handle authentication and authorization
            app.UseAuthentication();// Enable authentication middleware
            app.UseAuthorization(); // Enable authorization middleware


            app.MapControllers();

            app.Run();
        }
    }
}
