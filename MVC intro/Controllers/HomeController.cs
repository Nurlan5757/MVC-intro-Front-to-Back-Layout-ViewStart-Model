using Microsoft.AspNetCore.Mvc;

namespace MVC_intro.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index() 
        { 
            return View(); 
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
