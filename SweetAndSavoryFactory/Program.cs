using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SweetAndSavoryFactory.Models;
using Microsoft.AspNetCore.Identity;

namespace SweetAndSavoryFactory
{
  class Program
  {
    static void Main(string[] args)
    {

      WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

      builder.Services.AddControllersWithViews();

      builder.Services.AddDbContext<SweetAndSavoryFactoryContext>(
                        dbContextOptions => dbContextOptions
                          .UseMySql(
                            builder.Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:DefaultConnection"]
                          )
                        )
                      );

        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<SweetAndSavoryFactoryContext>()
        .AddDefaultTokenProviders();

      WebApplication app = builder.Build();

      app.UseDeveloperExceptionPage();
      app.UseHttpsRedirection();
      app.UseStaticFiles();

      app.UseRouting();
      app.UseAuthentication();
      app.UseAuthorization();

      app.MapControllerRoute(
          name: "default",
          pattern: "{controller=Home}/{action=Index}/{id?}"
        );

      app.Run();
    }
  }
}