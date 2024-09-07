using Microsoft.EntityFrameworkCore;
using Repositories;
using Services.Contracts;
using Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace OturumAc.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("sqlconnection"),
                    b => b.MigrationsAssembly("OturumAc"));

                options.EnableSensitiveDataLogging(true);
            });
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<RepositoryContext>();
        }

        public static void ConfigureSession(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = "OturumAc.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(10);
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public static void ConfigureServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IAuthService, AuthManager>();
        }

        public static void ConfigureApplicationCookie(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/Account/Login");
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                options.AccessDeniedPath = new PathString("/Account/AccessDenied");
            });
        }

        public static void ConfigureRouting(this IServiceCollection services)
        {
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = false;
            });
        }

    }
}
