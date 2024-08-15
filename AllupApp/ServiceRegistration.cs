using AllupApp.App_Data;
using AllupApp.Interfaces;
using AllupApp.Services;
using Microsoft.EntityFrameworkCore;

namespace AllupApp
{
    public static class ServiceRegistration
    {
        public static void Register(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllersWithViews();
            services.AddDbContext<AllupAppDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
            // addscopa, addtreansient, addsingleton
            services.AddScoped<ILayoutService, LayoutService>();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
            });
            services.AddHttpContextAccessor();
        }
    }
}
