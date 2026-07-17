using Microsoft.AspNetCore.Mvc;

namespace DetectiveCaseFileSystem.Controllers
{
    public class SuspectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
