using System.IO.Abstractions;
using System.Reflection;
using Adventskalender2018.Implementations.Infrastructure;
using Adventskalender2018.Interfaces.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;

namespace Adventskalender2018
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; private set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(configureOptions: options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.RegisterAssemblyPublicNonGenericClasses(
                    Assembly.GetExecutingAssembly(),
                    typeof(IFileSystem).Assembly)
                .AsPublicImplementedInterfaces();

#if DEBUG
            services.AddTransient<IDateTimeProvider, NachWeihnachtenDateTimeProvider>();
            //services.AddTransient<IDateTimeProvider, WorldClockApiDateTimeProvider>();
#else
            services.AddTransient<IDateTimeProvider, WorldClockApiDateTimeProvider>();
            //services.AddTransient<IDateTimeProvider, DefaultDateTimeProvider>();
#endif

            services.AddMvc().SetCompatibilityVersion(version: CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(errorHandlingPath: "/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(configureRoutes: routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
