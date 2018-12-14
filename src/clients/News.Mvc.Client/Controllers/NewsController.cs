using Microsoft.AspNetCore.Mvc;

namespace News.Mvc.Client.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            var allNews = ApiHttpClient.GetAllNews();
            return View(allNews);
        }
    }
}