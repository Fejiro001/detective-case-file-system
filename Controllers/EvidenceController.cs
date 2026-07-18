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
        [HttpPost]
        public IActionResult Create(Evidence evidence)
        {
            if (ModelState.IsValid)
            {
                evidence.Id = _nextId++;
                _evidences.Add(evidence);
                return RedirectToAction("Index");
            }
            return View(evidence);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var evidence = _evidences.FirstOrDefault(e => e.Id == id);
            if (evidence == null) return NotFound();
            return View(evidence);
        }
        [HttpPost]
        public IActionResult Edit(Evidence updatedEvidence)
        {
            if (!ModelState.IsValid)
            {
                return View(updatedEvidence);
            }
            var evidence = _evidences.FirstOrDefault(e => e.Id == updatedEvidence.Id);
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
            var evidence = _evidences.FirstOrDefault(e => e.Id == id);
            if (evidence != null)
            {
                _evidences.Remove(evidence);
            }
            return RedirectToAction("Index");
        }

        // Use ViewModel
        [HttpGet]
        public IActionResult Details(int id)
        {
            var evidence = _evidences.FirstOrDefault(e => e.Id == id);
            if (evidence == null) return NotFound();
            return View(evidence);
        }
    }
}
