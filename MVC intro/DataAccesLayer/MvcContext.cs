using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MVC_intro.Models;

namespace MVC_intro.DataAccesLayer
{
    public class MvcContext : DbContext
    {
        public MvcContext(DbContextOptions options) : base(options) 
        {          
        }
        public DbSet<Category> Categories {  get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=DESKTOP-8ABCEA9\\SQLEXPRESS;Database=106Pronia;Trusted_Connection=true;TrustServerCertificate=True");
            base.OnConfiguring(options);
        }
    }
}
