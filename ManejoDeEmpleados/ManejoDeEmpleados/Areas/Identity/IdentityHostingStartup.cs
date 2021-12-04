using System;
using ManejoDeEmpleados.Areas.Identity.Data;
using ManejoDeEmpleados.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ManejoDeEmpleados.Areas.Identity.IdentityHostingStartup))]
namespace ManejoDeEmpleados.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ManejoDeEmpleadosContext>(options =>
                    options.UseMySql("server=localhost;uid=root;pwd=Solohome;database=manejoempleados", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.25-mysql")));

                services.AddDefaultIdentity<ManejoDeEmpleadosUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<ManejoDeEmpleadosContext>();
            });
        }
    }
}