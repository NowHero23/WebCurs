using Microsoft.AspNetCore.Mvc;

namespace WebCurs2.Controllers
{
    public class ModalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
