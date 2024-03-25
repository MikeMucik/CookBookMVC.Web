using Microsoft.AspNetCore.Mvc;

namespace CookBookMVC.Web.Controllers
{
    public class BlogController : Controller
    {
        [Route("Blog/Art")]
        public IActionResult Article(string article)
        {
            return View();
        }
    }
}
