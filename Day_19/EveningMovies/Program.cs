using EveningMovies.Data;
using EveningMovies.Services;
using Microsoft.EntityFrameworkCore;

namespace EveningMovies
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite("Data Source=eveningmovies.db"));

            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IEveningMovieService, EveningMovieService>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.EnsureCreated();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Evening}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
