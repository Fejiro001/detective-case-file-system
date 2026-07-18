using DetectiveCaseFileSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace DetectiveCaseFileSystem.Controllers
{
    public class SuspectController : Controller
    {
        public static List<Suspect> Suspects = new List<Suspect>();
        private static int _nextId = 1;
        public IActionResult Index()
        {
            return View(Suspects);
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
                Suspects.Add(suspect);
                return RedirectToAction("Index");
            }
            return View(suspect);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var suspect = Suspects.FirstOrDefault(s => s.Id == id);
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
            var suspect = Suspects.FirstOrDefault(s => s.Id == updatedSuspect.Id);
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
            var suspect = Suspects.FirstOrDefault(s => s.Id == id);
            if (suspect != null)
            {
                Suspects.Remove(suspect);
            }
            return RedirectToAction("Index");
        }

        // Use ViewModel
        [HttpGet]
        public IActionResult Details(int id)
        {
            Suspect suspect = Suspects.FirstOrDefault(s => s.Id == id);
            if (suspect == null) return NotFound();
            Case foundCase = CaseController.Cases.FirstOrDefault(c => c.Id == suspect.CaseId);
            var vm = new SuspectViewModel
            {
                Id = suspect.Id,
                Name = suspect.Name,
                DateOfBirth = suspect.DateOfBirth,
                KnownAssociates = suspect.KnownAssociates,
                RiskLevel = suspect.RiskLevel,
                LastKnownLocation = suspect.LastKnownLocation,
                Aliases = suspect.Aliases,
                RoleInCase = suspect.RoleInCase,
                PhotoUrl = suspect.PhotoUrl,
                PhysicalDescription = suspect.PhysicalDescription,
                CaseId = foundCase.Id,
                CaseNumber = foundCase.CaseNumber,
                CaseTitle = foundCase.Title
            };
            return View(suspect);
        }
    }
}
