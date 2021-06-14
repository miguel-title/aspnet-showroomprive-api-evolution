using Hangfire;
using Hangfire.MemoryStorage;
using AtomicSeller;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using AtomicSeller.Models;
using AtomicSeller.Models.Data;
using AtomicJs.Helpers;

namespace AtomicSeller
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
              .AddCookie(options =>
              {
                  options.Cookie.HttpOnly = true;
                  options.Cookie.SecurePolicy = true
                    ? CookieSecurePolicy.None : CookieSecurePolicy.Always;
                  options.Cookie.SameSite = SameSiteMode.Lax;
              });

            services.AddSession(options =>
            {
                // 20 minutes later from last access your session will be removed.
                options.IdleTimeout = TimeSpan.FromMinutes(20);
            });

            services.AddHangfire(config =>
                config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                    .UseSimpleAssemblyNameTypeSerializer()
                    .UseDefaultTypeSerializer()
                    .UseSqlServerStorage(Configuration["Hangfire"]));
            //var toto = Configuration["Hangfire"];

            services.AddHangfireServer();
            services.AddSingleton<IRecurringJob, HangFireJob>();

            services.AddMemoryCache();
            services.AddMvc();

            services.AddDbContext<ASTJLEntities>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ASTJLEntities")));
            services.AddDbContext<ASTRDEntities>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ASTRDEntities")));
            services.AddDbContext<ASTLDEntities>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ASTLDEntities")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env,
            IBackgroundJobClient backgroundJobClient,
            IRecurringJobManager recurringJobManager,
            IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseMvcWithDefaultRoute();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");

            //app.UseHangfireDashboard();
            //app.UseHangfireDashboard("/hangfire", new DashboardOptions
            //{
            //    AppPath = "https://js.atomicseller.com/",
            //    Authorization = new[] { new ASAuthorizationFilter() }
            //});
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[] { new ASAuthorizationFilter() }
            });

            try
            {
                //backgroundJobClient.Enqueue(() => Console.WriteLine("AtomicSeller Hangfire job"));

                recurringJobManager.AddOrUpdate(
                    "Run every minute",
                    () => serviceProvider.GetService<IRecurringJob>().RecurringJob(),
                    "* * * * *"
                    );

            }
            catch (Exception ex)
            {
                string ErrorMessage = ex.Message;
            }

        }


    }
}
