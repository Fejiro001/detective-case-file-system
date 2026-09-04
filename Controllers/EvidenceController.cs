using DetectiveCaseFileSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DetectiveCaseFileSystem.Controllers
{
    public class EvidenceController : Controller
    {
        public static List<Evidence> Evidences = new List<Evidence>();
        private static int _nextId = 1;
        public IActionResult Index()
        {
            return View(Evidences);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Cases = new SelectList(CaseController.Cases, "Id", "Title");
            ViewBag.Suspects = SuspectController.Suspects.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult Create(Evidence evidence)
        {
            evidence.ImageUrl = "https://placehold.co/400x300/18181b/71717a?text=SECURE+FILE:+NO+VISUAL";

            if (ModelState.IsValid)
            {
                evidence.Id = _nextId++;
                Evidences.Add(evidence);
                return RedirectToAction("Index");
            }

            ViewBag.Cases = new SelectList(CaseController.Cases, "Id", "Title", evidence.CaseId);
            ViewBag.Suspects = SuspectController.Suspects.ToList();

            return View(evidence);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var evidence = Evidences.FirstOrDefault(e => e.Id == id);
            if (evidence == null) return NotFound();

            ViewBag.Cases = new SelectList(CaseController.Cases, "Id", "Title", evidence.CaseId);
            ViewBag.Suspects = SuspectController.Suspects.ToList();

            return View(evidence);
        }
        [HttpPost]
        public IActionResult Edit(Evidence updatedEvidence)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Cases = new SelectList(CaseController.Cases, "Id", "Title", updatedEvidence.CaseId);
                ViewBag.Suspects = SuspectController.Suspects.ToList();

                return View(updatedEvidence);
            }
            var evidence = Evidences.FirstOrDefault(e => e.Id == updatedEvidence.Id);
            if (evidence == null) return NotFound();

            evidence.Type = updatedEvidence.Type;
            evidence.Description = updatedEvidence.Description;
            evidence.DateCollected = updatedEvidence.DateCollected;
            evidence.LocationFound = updatedEvidence.LocationFound;
            evidence.ImageUrl = updatedEvidence.ImageUrl;
            evidence.CaseId = updatedEvidence.CaseId;
            evidence.SuspectId = updatedEvidence.SuspectId;

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var evidence = Evidences.FirstOrDefault(e => e.Id == id);
            if (evidence != null)
            {
                Evidences.Remove(evidence);
            }
            return RedirectToAction("Index");
        }

        // Use ViewModel
        [HttpGet]
        public IActionResult Details(int id)
        {
            Evidence evidence = Evidences.FirstOrDefault(e => e.Id == id);
            if (evidence == null) return NotFound();

            Case foundCase = CaseController.Cases.FirstOrDefault(c => c.Id == evidence.CaseId);

            // Only search for a suspect if a SuspectId actually exists
            Suspect suspect = evidence.SuspectId.HasValue
                ? SuspectController.Suspects.FirstOrDefault(s => s.Id == evidence.SuspectId)
                : null;

            var vm = new EvidenceViewModel
            {
                Id = evidence.Id,
                Type = evidence.Type,
                Description = evidence.Description,
                DateCollected = evidence.DateCollected,
                LocationFound = evidence.LocationFound,
                ImageUrl = evidence.ImageUrl,
                CaseId = foundCase?.Id ?? 0,
                CaseNumber = foundCase?.CaseNumber ?? "N/A",
                SuspectId = suspect?.Id ?? 0,
                SuspectName = suspect?.Name ?? "Unassigned"
            };
            return View(vm);
        }
    }
}
