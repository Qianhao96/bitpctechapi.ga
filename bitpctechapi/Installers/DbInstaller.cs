using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using bitpctechapi.Data;
using bitpctechapi.Services;

namespace bitpctechapi.Installers
{
    public class DbInstaller : IInstaller
    {
        public void Installservices(IServiceCollection services, IConfiguration configuration)
        {
            //test branch protection rule
            //UseSqlServer is used when want to connect to you local Sql server
            //Use this config when use "UseSqlServer" -- "Server=DESKTOP-ML8G5H8; Database=UserDB; Trusted_Connection=True; MultipleActiveResultSets=True"s
            //services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<DataContext>(options =>
                options.UseMySql(
                    configuration.GetConnectionString("DefaultConnection")));
            //"DefaultConnection": "server=192.168.20.213;port=3306;database=bitpctechtestdb;uid=bitpctechapi;password=password
            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<DataContext>();

            services.AddScoped<IPostService, PostService>();
        }
    }
}
