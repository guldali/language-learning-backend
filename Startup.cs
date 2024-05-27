using Microsoft.Extensions.DependencyInjection;
using YourNamespace.Services;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {

        services.AddScoped<UserService>();
        services.AddScoped<CourseService>();

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Configure metodu içeriği...
    }
}

