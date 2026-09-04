using DetectiveCaseFileSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            ViewBag.Cases = new SelectList(CaseController.Cases, "Id", "Title");
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
            ViewBag.Cases = new SelectList(CaseController.Cases, "Id", "Title", suspect.CaseId);
            return View(suspect);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var suspect = Suspects.FirstOrDefault(s => s.Id == id);
            if (suspect == null) return NotFound();

            ViewBag.Cases = new SelectList(CaseController.Cases, "Id", "Title", suspect.CaseId);

            return View(suspect);
        }
        [HttpPost]
        public IActionResult Edit(Suspect updatedSuspect)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Cases = new SelectList(CaseController.Cases, "Id", "Title", updatedSuspect.CaseId);

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
                CaseId = foundCase?.Id ?? 0,
                CaseNumber = foundCase?.CaseNumber ?? "N/A",
                CaseTitle = foundCase?.Title ?? "Unknown Case"
            };
            return View(vm);
        }
    }
}
