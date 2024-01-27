using HMS;
using HMS.Models;
using HMS.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI;

namespace HMS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
//using HMS;
//using HMS.Models;
//using HMS.Services;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.Options;
//using MongoDB.Driver;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using WebAPI;

//namespace HMS
//{
//    public class Startup
//    {
//        private readonly IConfiguration _configuration;

//        public Startup(IConfiguration configuration)
//        {
//            _configuration = configuration;
//        }

//        public void ConfigureServices(IServiceCollection services)
//        {
//            services.Configure<AppointmentDatabaseSettings>(_configuration.GetSection(nameof(AppointmentDatabaseSettings)));
//            services.AddSingleton<IAppointmentDatabaseSettings>(sp => sp.GetRequiredService<IOptions<AppointmentDatabaseSettings>>().Value);
//            services.AddSingleton<IMongoClient>(s => new MongoClient(_configuration.GetValue<string>("AppointmentsStoreDatabaseSettings:ConnectionString")));
//            services.AddScoped<IAppointmentService, AppointmentService>();

//            // Add other services and configurations as needed

//            services.AddControllers();
//        }

//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            // Configure the app's middleware and routing

//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }
//            else
//            {
//                // Configure for production environment
//                app.UseExceptionHandler("/Home/Error");
//                app.UseHsts();
//            }

//            app.UseHttpsRedirection();
//            app.UseStaticFiles();

//            app.UseRouting();

//            app.UseAuthorization();

//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapControllers();
//            });
//        }
//    }
//}

