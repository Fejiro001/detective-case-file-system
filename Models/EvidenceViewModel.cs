namespace DetectiveCaseFileSystem.Models
{
    public class EvidenceViewModel
    {
        // All Evidence properties
        public int Id { get; set; }
        public string Type { get; set; }
        public string? Description { get; set; }
        public DateTime DateCollected { get; set; }
        public string LocationFound { get; set; }
        public string? ImageUrl { get; set; }

        // Just important Case info to display
        public int CaseId { get; set; }
        public string CaseNumber { get; set; }

        // Optional Suspect info attached
        public int? SuspectId { get; set; }
        public string? SuspectName { get; set; }
    }
}
