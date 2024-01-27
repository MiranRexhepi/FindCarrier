using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using System.IO;
using Microsoft.Extensions.FileProviders;
using MongoDB.Driver;
using HMS.Models;
using HMS.Services;
using Microsoft.Extensions.Options;

namespace WebAPI
{
    public class Startup
    {
        private readonly object AppointmentStoreDatabaseSettings;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add the following code
            //services.Configure<AppointmentDatabaseSettings>(Configuration.GetSection(nameof(AppointmentDatabaseSettings)));
            //services.AddSingleton<IAppointmentDatabaseSettings>(sp =>
            //    sp.GetRequiredService<IOptions<AppointmentDatabaseSettings>>().Value);
            //services.AddSingleton<IMongoClient>(s =>
            //    new MongoClient(Configuration.GetValue<string>("AppointmentStoreDatabaseSettings:ConnectionString")));
            //services.AddScoped<IAppointmentService, AppointmentService>();
            services.Configure<AppointmentDatabaseSettings>(Configuration.GetSection(nameof(AppointmentStoreDatabaseSettings)));
            services.AddSingleton<IAppointmentDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<AppointmentDatabaseSettings>>().Value);
            services.AddSingleton<IMongoClient>(s =>
                new MongoClient(Configuration.GetValue<string>("AppointmentStoreDatabaseSettings:ConnectionString")));
            services.AddScoped<IAppointmentService, AppointmentService>();

            services.AddMvc();
            services.AddControllers();
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod()
                    .AllowAnyHeader());
            });

            // JSON Serializer
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
                    = new DefaultContractResolver());

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // app.UseStaticFiles(new StaticFileOptions
            // {
            //     FileProvider = new PhysicalFileProvider(
            //         Path.Combine(Directory.GetCurrentDirectory(), "Photos")),
            //     RequestPath = "/Photos"
            // });
        }
    }
}


//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Newtonsoft.Json.Serialization;
//using System.IO;
//using Microsoft.Extensions.FileProviders;
////using Microsoft.AspNetCore.Authentication.JwtBearer;
////using Microsoft.IdentityModel.Tokens;
//using System.Text;

//namespace WebAPI
//{
//    public class Startup
//    {
//        public Startup(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }

//        public IConfiguration Configuration { get; }

//        // This method gets called by the runtime. Use this method to add services to the container.
//        public void ConfigureServices(IServiceCollection services)
//        {

//            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//            //    .AddJwtBearer(options =>
//            //    {
//            //        options.TokenValidationParameters = new TokenValidationParameters
//            //        {
//            //            ValidateIssuer = true,
//            //            ValidateAudience = true,
//            //            ValidateLifetime = true,
//            //            ValidateIssuerSigningKey = true,
//            //            ValidIssuer = Configuration["Jwt:Issuer"],
//            //            ValidAudience = Configuration["Jwt:Audience"],
//            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))



//            //        };
//            //    });
//            services.AddMvc();
//            services.AddControllers();
//            services.AddCors(c =>
//            {
//                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod()
//                .AllowAnyHeader());
//            });

//            //JSON Serializer
//            services.AddControllersWithViews()
//                .AddNewtonsoftJson(options =>
//                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft
//                .Json.ReferenceLoopHandling.Ignore)
//                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
//                = new DefaultContractResolver());

//            services.AddControllers();
//        }

//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }



//            app.UseRouting();

//            app.UseAuthentication();

//            app.UseAuthorization();

//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapControllers();
//            });


//            //app.UseStaticFiles(new StaticFileOptions
//            //{
//            //    FileProvider = new PhysicalFileProvider(
//            //        Path.Combine(Directory.GetCurrentDirectory(), "Photos")),
//            //    RequestPath = "/Photos"
//            //});
//        }
//    }
//}
