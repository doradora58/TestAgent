using WebApplication1.Data;
using WebApplication1.Repositories;
using WebApplication1.Services;

namespace WebApplication1;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddCors(options =>
        {
            options.AddPolicy("AllowReact",policy =>
            {
                policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            });
        });
        AddTaskServices(services);
    }

    private void AddTaskServices(IServiceCollection services)
    {
        services.AddScoped<ITaskService, TaskService>();
        services.AddScoped<ITaskRepository, TaskRepository>();
        //services.AddDbContext<AppDbContext>(options =>
        //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        services.AddSingleton<IAppDbContext, AppDbContextStub>(); //TODO

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // if (env.IsDevelopment())
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseRouting();
        //app.UseAuthorization();

        app.UseCors("AllowReact");

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}