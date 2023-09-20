using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mvcprojectfinal.Hubs;
using mvcprojectfinal.Models;
using mvcprojectfinal.Repository;

namespace mvcprojectfinal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Cs"));
            }
            );
            builder.Services.AddIdentity<AppliacationUser, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
            }
           ).AddEntityFrameworkStores<Context>();//register (signinmanager-usermanager -rolemanager)

            builder.Services.AddScoped<IHotelRepository, HotelRepository>();
            builder.Services.AddScoped<ICityRepository, CityRepository>();
            builder.Services.AddScoped<IImageRepository, ImageRepo > ();
            builder.Services.AddScoped<IRoomRepository, RoomRepository>();
            builder.Services.AddScoped<IBookingRepository, BookingRepository>();    
			
            builder.Services.AddSignalR();

			var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

			app.UseRouting();
			app.MapHub<HotelHub>("/HotelHub");
			app.MapHub<FeedBackHub>("/FeedbackHub");
			app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}