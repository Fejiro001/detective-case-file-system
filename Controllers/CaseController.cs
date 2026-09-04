using DetectiveCaseFileSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace DetectiveCaseFileSystem.Controllers
{
    public class CaseController : Controller
    {
        public static List<Case> Cases = new List<Case>();
        private static int _nextId = 1;
        public IActionResult Index()
        {
            return View(Cases);
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
                Cases.Add(newCase);
                return RedirectToAction("Index");
            }
            return View(newCase);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var foundCase = Cases.FirstOrDefault(c => c.Id == id);
            if (foundCase == null) return NotFound();
            return View(foundCase);
        }
        [HttpPost]
        public IActionResult Edit(Case updatedCase)
        {
            if (!ModelState.IsValid)
            {
                return View(updatedCase);
            }
            var foundCase = Cases.FirstOrDefault(c => c.Id == updatedCase.Id);
            if (foundCase == null) return NotFound();

            foundCase.CaseNumber = updatedCase.CaseNumber;
            foundCase.Title = updatedCase.Title;
            foundCase.Description = updatedCase.Description;
            foundCase.CrimeType = updatedCase.CrimeType;
            foundCase.PriorityLevel = updatedCase.PriorityLevel;
            foundCase.Location = updatedCase.Location;
            foundCase.Status = updatedCase.Status;
            foundCase.TimeOfCrime = updatedCase.TimeOfCrime;
            foundCase.Investigator = updatedCase.Investigator;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var foundCase = Cases.FirstOrDefault(c => c.Id == id);
            if (foundCase == null) return NotFound();

            var vm = new CaseViewModel
            {
                Case = foundCase,
                Suspects = SuspectController.Suspects.Where(s => s.CaseId == id),
                Evidences = EvidenceController.Evidences.Where(e => e.CaseId == id)
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var foundCase = Cases.FirstOrDefault(c => c.Id == id);
            if (foundCase != null)
            {
                Cases.Remove(foundCase);
            }
            return RedirectToAction("Index");
        }
    }
}
