using Microsoft.AspNetCore.Mvc;
using News.Mvc.Client.Models;

namespace News.Mvc.Client.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserModel model)
        {
            return null;
        }
    }
}