using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vehicle_Service_Final_Proj.Models;

[assembly: HostingStartup(typeof(Vehicle_Service_Final_Proj.Areas.Identity.IdentityHostingStartup))]
namespace Vehicle_Service_Final_Proj.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Vehicle_Service_IdentityDB>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Vehicle_Service_IdentityDBConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<Vehicle_Service_IdentityDB>();
            });
        }
    }
}