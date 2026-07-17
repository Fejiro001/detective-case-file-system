using Microsoft.AspNetCore.Mvc;

namespace DetectiveCaseFileSystem.Controllers
{
    public class EvidenceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
