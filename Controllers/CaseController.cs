using DetectiveCaseFileSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace DetectiveCaseFileSystem.Controllers
{
    public class CaseController : Controller
    {
        private static List<Case> _cases = new List<Case>();
        private static int _nextId = 1;
        public IActionResult Index()
        {
            return View(_cases);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Case newCase)
        {
            if (ModelState.IsValid)
            {
                newCase.Id = _nextId++;
                _cases.Add(newCase);
                return RedirectToAction("Index");
            }
            return View(newCase);
        }
    }
}
