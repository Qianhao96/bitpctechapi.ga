using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using bitpctechapi.Data;
using bitpctechapi.Services;
using Microsoft.AspNetCore.Hosting;

namespace bitpctechapi.Installers
{
    public class DbInstaller : IInstaller
    {
        public void Installservices(IServiceCollection services, IConfiguration configuration, IHostingEnvironment env)
        {
            if (env.IsProduction())
            {
                services.AddDbContext<DataContext>(options =>
                options.UseMySql(
                    configuration.GetConnectionString("LiveConnection")));
            }
            else
            {
                services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("lqhDevConnection")));
            }
            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<DataContext>();

            services.AddScoped<IPostService, PostService>();
        }
    }
}
