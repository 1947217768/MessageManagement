using Alexinea.Autofac.Extensions.DependencyInjection;
using Autofac;
using AutoMapper;
using Message.Core.Models;
using Message.Entity.Mapping;
using Message.Repository;
using Message.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

namespace Message.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.

        [Obsolete]
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            var connection = Configuration.GetConnectionString("DefaultSqlServer");
            services.AddDbContext<MessageManagementContext>(options => options.UseSqlServer(connection));
            //注入服务
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //初始化Redis
            var csredis = new CSRedis.CSRedisClient(Configuration.GetSection("RedisConnectionStrins")["DefaultRedis"]);
            RedisHelper.Initialization(csredis);
            services.AddControllers();
            services.AddAutoMapper();
            services.AddRazorPages();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddAntiforgery(options =>
            {
                options.FormFieldName = "AntiforgeryFieldname";
                options.HeaderName = "X-CSRF-TOKEN-Header";
                options.SuppressXFrameOptionsHeader = false;
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
          .AddCookie(options =>
          {
              options.LoginPath = "/Admin/Account/Index";
              options.LogoutPath = "/Admin/Account/Logout";
              options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
          });
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(15);
                options.Cookie.HttpOnly = true;
            });
            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterAssemblyTypes(typeof(MenuRepository).Assembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(MenuService).Assembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces();
            builder.RegisterType<UserInfoService>().InstancePerRequest();
            builder.RegisterType<UserRoleRepository>().InstancePerRequest();

            return new AutofacServiceProvider(builder.Build());
        }

        //运行时调用此方法。使用此方法配置HTTP请求管道。
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                endpoints.MapAreaControllerRoute(
                    name: "areas",
                    areaName: "Admin",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            AppDependencyResolver.Init(app.ApplicationServices);
        }
    }
}
