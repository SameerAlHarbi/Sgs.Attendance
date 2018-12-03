using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sameer.Shared.Helpers.Mvc;
using Sgs.Attendance.Mvc.Services;

namespace Sgs.Attendance.Mvc
{
    public class Startup
    {
        private IConfiguration _config { get; }
        IHostingEnvironment _env;

        public Startup(IConfiguration configuration
            , IHostingEnvironment environment)
        {
            _config = configuration;
            _env = environment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IAppInfo, AppInfo>();

            services.AddAutoMapper();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app
            , IHostingEnvironment env
            , ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(_config.GetSection("Logging"));
            loggerFactory.AddDebug();

            //Catch all exception that happens in any middeleware and showed the developer
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseNodeModules(env.ContentRootPath);

            app.UseMvc(configureRoute);
        }

        private void configureRoute(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute(name: "users",
                   template: "Users/{action=Index}/{username?}",
                   defaults: new { controller = "Users" });

            routeBuilder.MapRoute("Default",
                "{controller=Home}/{action=Index}/{id?}");

        }
    }
}
