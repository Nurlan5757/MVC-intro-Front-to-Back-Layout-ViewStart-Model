using MVC_intro.DataAccesLayer;

namespace MVC_intro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<MvcContext>();
            
            var app = builder.Build();



            app.UseStaticFiles();

            app.MapControllerRoute("areas", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
        
            app.MapControllerRoute("defaut", "{controller=Home}/{action=Index}/{id?}");
            app.Run();
        }
    }
}
