using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sameer.Shared;
using Sameer.Shared.Helpers.Mvc;
using Sgs.Attendance.Mvc.Models;
using Sgs.Attendance.Mvc.Services;
using System.Net.Http.Headers;

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

            services.AddHttpClient<IDataManager<DepartmentModel>,GeneralApiDataManager<DepartmentModel>>(client =>
            {
                client.BaseAddress = new System.Uri(@"http://localhost:8088/api/departmentsinfo");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType: "application/json"));
            });

            services.AddHttpClient<IDataManager<DeviceInfoModel>, GeneralApiDataManager<DeviceInfoModel>>(client =>
            {
                client.BaseAddress = new System.Uri(@"http://localhost:8088/api/devicesinfo");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType: "application/json"));
            });

            services.AddSingleton<IAppInfo, AppInfo>();

            services.AddAutoMapper();

            services.AddMvc();

            services.AddKendo();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app
            , IHostingEnvironment env
            , ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error/500");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }

            app.UseStaticFiles();

            app.UseNodeModules(env.ContentRootPath);

            app.UseMvc(configureRoute);
        }

        private void configureRoute(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default",
                "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
