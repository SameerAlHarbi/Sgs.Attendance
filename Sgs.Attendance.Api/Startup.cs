using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sameer.Shared.Data;
using Sgs.Attendance.Api.Services;
using Sgs.Attendance.DataAccess;
using Sgs.Attendance.ERP;
using System;
using System.Net.Http.Headers;

namespace Sgs.Attendance.Api
{
    public class Startup
    {
        private IConfiguration _config { get; }
        private IHostingEnvironment _env;

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
            services.AddSameerDbDataManagers<AttendanceDb>(_config);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddHttpClient<IErpManager, ErpManager>(client =>
            {
                client.BaseAddress = new System.Uri(@"http://localhost:8257/api/Hr/portal/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType: "application/json"));
            });

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<ISmsSender, SmsSender>();

            //CORS
            services.AddCors(cfg =>
            {

                cfg.AddPolicy("AttendanceSys", bldr =>
                {
                    bldr.AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithOrigins("http://attendance-system.com");
                });

                cfg.AddPolicy("AnyGET", bldr =>
                {
                    bldr.AllowAnyHeader()
                        .WithMethods("GET")
                        .AllowAnyOrigin();
                });

                cfg.AddPolicy("Any", bldr =>
                {
                    bldr.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                });

            });

            //AutoMapper
            services.AddAutoMapper();

            //Caching
            services.AddResponseCaching(options =>
            {
                options.MaximumBodySize = 1024;
            });

            services.AddMvc()
                .AddJsonOptions(opt => 
                opt.SerializerSettings.ReferenceLoopHandling 
                = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddXmlDataContractSerializerFormatters()// to add xml serializer
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

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
                app.UseExceptionHandler("/api/Errors/500");
                app.UseStatusCodePagesWithReExecute("/api/Errors/{0}");
            }

            app.UseResponseCaching();

            app.Use(async (context, next) =>
            {
                // For GetTypedHeaders, add: using Microsoft.AspNetCore.Http;
                context.Response.GetTypedHeaders().CacheControl =
                    new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromSeconds(10)
                    };
                context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
                    new string[] { "Accept-Encoding" };

                await next();
            });


            app.UseMvc();
        }
    }
}
