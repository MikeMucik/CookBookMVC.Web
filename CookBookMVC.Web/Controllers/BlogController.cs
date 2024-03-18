using Microsoft.AspNetCore.Mvc;

namespace CookBookMVC.Web.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Article(string article)
        {
            return View();
        }
    }
}
