using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using My.Otomasyon.Business.Concrete;
using My.Otomasyon.Business.CostumExtensions.CostumIdentity;
using My.Otomasyon.Business.CostumExtensions.Depandecies;
using My.Otomasyon.Business.Interfaces;
using My.Otomasyon.DataAccess.Concrete.Context;
using My.Otomasyon.DataAccess.Concrete.EfCore;
using My.Otomasyon.DataAccess.Interfaces;
using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.Otomasyon.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            

            services.AddControllersWithViews();
            services.AddDbContext <OtomasyonContext>();
             services.AddMyIdentity();
           

            services.AddDepandencies();
           


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //IdentityInitializer.SeedData(userManager, roleManager).Wait();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{int?}"
                    );
            });
        }
    }
}
