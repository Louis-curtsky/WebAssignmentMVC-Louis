using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignmentMVC.Models.Identity;
using WebAssignmentMVC.Models.Person;
using WebAssignmentMVC.Models.Person.Data;
using WebAssignmentMVC.Models.Person.Repo;
using WebAssignmentMVC.Models.Person.Services;

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
            // -------------Connection to Database
               services.AddDbContext<PersonDBContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //------------------------- Identity -------------------------------------------------------
/*            services.AddIdentity<AppUser, IdentityRole>()
                        .AddRoles<IdentityRole>()
                        .AddEntityFrameworkStores<PersonDBContext>()
                        .AddDefaultTokenProviders();*/

            // -------------------- IOC ------------------------
            services.AddScoped<IPeopleRepo, IMemoryPeopleRepo>();//Container setting for my IoC
            services.AddScoped<IPeopleService, PeopleService>();//Container setting for my IoC

            services.AddScoped<ICountryRepo, DbCountryRepo>();
            services.AddScoped<ICountryService, CountryService>();

            services.AddScoped<ICityRepo, DbCityRepo>();
            services.AddScoped<ICityService, CityService>();

            services.AddScoped<ILanguageRepo, DbLanguageRepo>();
            services.AddScoped<ILanguageService, LanguageService>();

            services.AddControllersWithViews(); 

            services.AddMvc().AddRazorRuntimeCompilation();

            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<PersonDBContext>()
                .AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
 
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );

            });
        }
    }
}
