using EmbeddedStock.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmbeddedStock
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            using(var db = new DatabaseContext())
            {
                db.Database.EnsureCreated();
            }

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddTransient<IComponentTypeRepository, ComponentTypeRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IComponentRepository, ComponentRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                //app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Category}/{action=Index}/{id?}");
            });
        }
    }
}
