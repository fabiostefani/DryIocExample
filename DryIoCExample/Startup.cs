using DryIoc;
using DryIoCExample.Data;
using DryIoCExample.Infra;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DryIoCExample
{
    public class Startup
    {

        public Startup(IHostEnvironment env/*IConfiguration configuration*/)
        {            
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();           
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {                        
            services.AddControllers();            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DryIoCExample", Version = "v1" });
            });
            services.AddDbContext<OrderContext>(opt => opt.UseInMemoryDatabase("order"));            
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            IContainer container = app.ApplicationServices.GetRequiredService<IContainer>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DryIoCExample v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureContainer(IContainer container)
        {
            DryIocConfig.Register(container);                        
        }
    }
}
