using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignmentMVC.Models.Person;

namespace WebAssignmentMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            // To allow Sessions and Cookies operations

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(5);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            //services.AddScoped<IPeopleService, PeopleService>();//Container setting for my IoC
            //services.AddControllersWithViews(); //Will be used later maybe
            services.AddMvc().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseSession();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "PeopleRoute",
                    pattern: "/People/AddPerson",
                    defaults: new { controller = "Person", action = "Create" }
                    );

                endpoints.MapControllerRoute(
                    name: "PeopleRoute",
                    pattern: "/People/SearchforPerson",
                    defaults: new { controller = "Person", action = "FindPerson" }
                    );

                endpoints.MapControllerRoute(
                    name: "PeopleRoute",
                    pattern: "/People/FindThePerson",
                    defaults: new { controller = "Person", action = "Searching" }
                    );

                endpoints.MapControllerRoute(
                    name: "finalRoute",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );

            });
        }
    }
}
