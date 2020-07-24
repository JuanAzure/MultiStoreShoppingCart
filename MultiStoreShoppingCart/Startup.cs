using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MultiStoreShoppingCart.Extensions;
using MultiStoreShoppingCart.Models;

namespace MultiStoreShoppingCart
{
    public class Startup
    {

        public IConfiguration configuration { get; }

        public Startup(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Schema_Customer";
            })
                .AddCookie("Schema_Admin", options =>
                {
                    options.LoginPath = "/admin/login";
                    options.LogoutPath = "/admin/admin/login";
                    options.AccessDeniedPath = "/admin/login/accessDenied";
                })
                 .AddCookie("Schema_Vendor", options =>
                 {
                     options.LoginPath = "/vendor/login";
                     options.LogoutPath = "/vendor/login/logout";
                     options.AccessDeniedPath = "/admin/login/accessDenied";
                 })
                  .AddCookie("Schema_Customer", options =>
                  {
                      options.LoginPath = "/customer/login";
                      options.LogoutPath = "/customer/login/logout";
                      options.AccessDeniedPath = "/customer/login/accessDenied";
                  })
                ;


           services.AddControllersWithViews();
            
          services.AddDbContext<DatabaseContext>(
          options => options.UseLazyLoadingProxies()
                            .UseSqlServer(configuration.GetConnectionString("myDb1")));

            services.ConfigureRepositoryWrapper();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.Use(async (context, next) =>
            {
                var principal = new ClaimsPrincipal();

                var result1 = await context.AuthenticateAsync("Schema_Admin");
                if (result1?.Principal!=null)
                {
                    principal.AddIdentities(result1.Principal.Identities);
                }

                var result2 = await context.AuthenticateAsync("Schema_Vendor");
                if (result2?.Principal != null)
                {
                    principal.AddIdentities(result2.Principal.Identities);
                }

                var result3 = await context.AuthenticateAsync("Schema_Customer");
                if (result3?.Principal != null)
                {
                    principal.AddIdentities(result3.Principal.Identities);
                }
                context.User = principal;
                await next();
            });

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

