using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    public class ChatController : Controller
    {
        [Route("/chat")]
        public IActionResult Chat()
        {
            return View();
        }
    }
}
