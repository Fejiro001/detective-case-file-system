namespace DetectiveCaseFileSystem.Models
{
    public class EvidenceViewModel
    {
        // Evidence
        public int Id { get; set; }
        public string Type { get; set; }
        public string? Description { get; set; }
        public DateTime DateCollected { get; set; }
        public string LocationFound { get; set; }
        public string? ImageUrl { get; set; }

        // Case
        public int CaseId { get; set; }
        public string CaseNumber { get; set; }
        public string Title { get; set; }
        public string? CaseDescription { get; set; }
        public CrimeType CrimeType { get; set; }
        public PriorityLevel PriorityLevel { get; set; }
        public string Location { get; set; }
        public Status Status { get; set; }
        public DateTime? TimeOfCrime { get; set; }
        public string Investigator { get; set; }

        // Suspect
        public int SuspectId { get; set; }
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? KnownAssociates { get; set; }
        public RiskLevel RiskLevel { get; set; }
        public string? LastKnownLocation { get; set; }
        public string? Aliases { get; set; }
        public RoleInCase RoleInCase { get; set; }
        public string? PhotoUrl { get; set; } = "https://api.dicebear.com/8.x/pixel-art/svg?seed=Unknown";
        public string? PhysicalDescription { get; set; }
    }
}
