using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_intro.DataAccesLayer;
using MVC_intro.ViewModels.Categories;
using System.Linq;

namespace MVC_intro.Controllers
{
    public class HomeController : Controller
    {
        private readonly MvcContext _context;

        public HomeController(MvcContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index() 
        {
            var data = await _context.Categories
                .Where(x=> x.IsDeleted==false)
                .Select(x=> new GetCategoryVM
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                //.Take(4)
                .ToListAsync();
            return View(data); 
        }
        public async Task<IActionResult> Test(int? id)
        {
            if (id == null || id < 1) return BadRequest();
            var cat = await _context.Categories.FindAsync(id);
            if (cat == null) return NotFound();
            _context.Categories.Remove(cat);
            await _context.SaveChangesAsync();
            return Content(cat.Name);
        }
        public async Task<IActionResult> CountacUs()
        {
            return View();
        }
        public async Task<IActionResult> AboutUs()
        {
            return View();
        }
        public async Task<IActionResult> Shop()
        {
            return View();
        }


    }
}
