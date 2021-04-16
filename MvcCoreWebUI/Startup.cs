using Business.Abstract;
using Business.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvcCoreWebUI.Identity;
using MvcCoreWebUI.Services.CartSession;
using MvcCoreWebUI.Services.WishListSession;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreWebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        private IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //services.AddMvc().AddNewtonsoftJson(opt =>
            //{
            //    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //});
            #region Dependency Injection
            services.AddSingleton<ICartService, CartManager>();
            services.AddSingleton<IWishListService, WishListManager>();
            #endregion

            #region DbConnectionOptions
            services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            #endregion

            #region IdentityOptions
            services.AddIdentity<AppIdentityUser, AppIdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.AllowedForNewUsers = true;
                options.User.RequireUniqueEmail = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });
            #endregion

            #region Session Settings
            services.AddSingleton<ICartSessionService, CartSessionManager>();
            services.AddSingleton<IWishListSessionService, WishListSessionManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSession();
            services.AddDistributedMemoryCache();
            #endregion

            #region Cookie Settings
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(1);

                options.Cookie = new CookieBuilder()
                {
                    HttpOnly = true,
                    Path = "/",
                    Name = ".MollaDress.Security.Cookie",
                    SameSite = SameSiteMode.Lax,
                    SecurePolicy = CookieSecurePolicy.SameAsRequest
                };
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            #region Panel Routing
            app.UseEndpoints(endpoints =>
            {
                //  endpoints.MapControllerRoute(
                //  name: "admin-product-add",
                //  pattern: "{area:exists}/Product/Add",
                //  defaults: new {controller="Product",action= "Add" }
                //);

                endpoints.MapControllerRoute(
                  name: "admin-panel",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
            #endregion

            #region Site Routing
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "product-detail",
                pattern: "product/detail/{productId?}",
                defaults: new {controller="Product", action="Detail" });

                endpoints.MapControllerRoute(
                 name: "default",
                 pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            #endregion
         
        }
    }
}
