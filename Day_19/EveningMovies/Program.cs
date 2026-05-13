using EveningMovies.Services;

namespace EveningMovies
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IEveningMovieService, EveningMovieService>();

            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Evening}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
