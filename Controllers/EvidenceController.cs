using DetectiveCaseFileSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace DetectiveCaseFileSystem.Controllers
{
    public class EvidenceController : Controller
    {
        private static List<Evidence> _evidences = new List<Evidence>();
        private static int _nextId = 1;
        public IActionResult Index()
        {
            return View(_evidences);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
