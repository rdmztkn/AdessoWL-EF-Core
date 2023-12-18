using AdessoWL.Application;
using AdessoWL.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSwag;

namespace AdessoWL.WebApi;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

        services.AddControllers();
        services.AddSwaggerDocument(config =>
            config.PostProcess = (settings =>
            {
                settings.Info.Title = "AdessoWL.WebApi";
                settings.Info.Description = "Adesso World League";
                settings.Info.Contact = new OpenApiContact
                {
                    Email = "erdemoztekin@hotmail.com",
                    Name = "Erdem OZTEKIN",
                    Url = "https://github.com/rdmztkn",
                };
                settings.Info.Version = "v1";
            }
        ));
        services.AddPersistenceDependencies(Configuration);
        services.AddApplicationDependencies();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }



        app.UseOpenApi();

        app.UseSwaggerUi3();

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();


        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.UseHsts();
    }
}
