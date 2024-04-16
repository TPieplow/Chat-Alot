using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }
    }
}
