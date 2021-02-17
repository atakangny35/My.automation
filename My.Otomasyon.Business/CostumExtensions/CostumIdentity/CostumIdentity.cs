using Microsoft.Extensions.DependencyInjection;
using My.Otomasyon.DataAccess.Concrete.Context;
using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace My.Otomasyon.Business.CostumExtensions.CostumIdentity
{
    public static class CostumIdentity
    {
        public static void AddMyIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(opt =>
            {

                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 5;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireNonAlphanumeric = false;
            })
           .AddEntityFrameworkStores<OtomasyonContext>();
            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "User";
                opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(20);
                opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;

                opt.LoginPath = "/Login/Index";
            });

        }
    }
}
