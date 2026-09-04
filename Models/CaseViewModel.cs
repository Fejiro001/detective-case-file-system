namespace DetectiveCaseFileSystem.Models
{
    public class CaseViewModel
    {
        public required Case Case { get; set; }
        public IEnumerable<Suspect> Suspects { get; set; } = new List<Suspect>();
        public IEnumerable<Evidence> Evidences { get; set; } = new List<Evidence>();
    }
}
