using DetectiveCaseFileSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace DetectiveCaseFileSystem.Controllers
{
    public class SuspectController : Controller
    {
        private static List<Suspect> _suspects = new List<Suspect>();
        private static int _nextId = 1;
        public IActionResult Index()
        {
            return View(_suspects);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Suspect suspect)
        {
            if (ModelState.IsValid)
            {
                suspect.Id = _nextId++;
                _suspects.Add(suspect);
                return RedirectToAction("Index");
            }
            return View(suspect);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var suspect = _suspects.FirstOrDefault(s => s.Id == id);
            if (suspect == null) return NotFound();
            return View(suspect);
        }
        [HttpPost]
        public IActionResult Edit(Suspect updatedSuspect)
        {
            if (!ModelState.IsValid)
            {
                return View(updatedSuspect);
            }
            var suspect = _suspects.FirstOrDefault(s => s.Id == updatedSuspect.Id);
            if (suspect == null) return NotFound();

            suspect.Name = updatedSuspect.Name;
            suspect.DateOfBirth = updatedSuspect.DateOfBirth;
            suspect.KnownAssociates = updatedSuspect.KnownAssociates;
            suspect.RiskLevel = updatedSuspect.RiskLevel;
            suspect.LastKnownLocation = updatedSuspect.LastKnownLocation;
            suspect.Aliases = updatedSuspect.Aliases;
            suspect.RoleInCase = updatedSuspect.RoleInCase;
            suspect.PhotoUrl = updatedSuspect.PhotoUrl;
            suspect.PhysicalDescription = updatedSuspect.PhysicalDescription;
            suspect.CaseId = updatedSuspect.CaseId;
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var suspect = _suspects.FirstOrDefault(s => s.Id == id);
            if (suspect != null)
            {
                _suspects.Remove(suspect);
            }
            return RedirectToAction("Index");
        }

        // Use ViewModel
        [HttpGet]
        public IActionResult Details(int id)
        {
            var suspect = _suspects.FirstOrDefault(s => s.Id == id);
            if (suspect == null) return NotFound();
            return View(suspect);
        }
    }
}
