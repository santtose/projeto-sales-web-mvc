using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalesWebMvc.Areas.Identity.Data;

[assembly: HostingStartup(typeof(SalesWebMvc.Areas.Identity.IdentityHostingStartup))]
namespace SalesWebMvc.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SalesWebMvcIdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("SalesWebMvcIdentityContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<SalesWebMvcIdentityContext>();
            });
        }
    }
}