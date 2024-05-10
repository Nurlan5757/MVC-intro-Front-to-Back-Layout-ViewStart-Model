using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_intro.DataAccesLayer;


namespace MVC_intro.ViewModels.Sliders
{
    public class DeleteSliderVM : Controller
    {
        private readonly MvcContext _context;

        public DeleteSliderVM(MvcContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _context.Sliders
                .Where(x => x.IsDeleted == false)
                .Select(x => new GetSliderVM
                {
                    Id = x.Id,
                    Title= x.Title,
                    Subtitle= x.Subtitle,
                    Discount= x.Discount,
                    ImageUrl= x.ImageUrl,                                   
                })
                //.Take(4)
                .ToListAsync();
            return View(data);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 1) return BadRequest();
            var dl = await _context.Sliders.FindAsync(id);
            if (dl == null) return NotFound();
            _context.Sliders.Remove(dl);
            await _context.SaveChangesAsync();
            return Content(dl.Title);
        }
    }
}
