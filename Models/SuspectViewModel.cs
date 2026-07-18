namespace DetectiveCaseFileSystem.Models
{
    public class SuspectViewModel
    {
        // All Suspect info
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? KnownAssociates { get; set; }
        public RiskLevel RiskLevel { get; set; }
        public string? LastKnownLocation { get; set; }
        public string? Aliases { get; set; }
        public RoleInCase RoleInCase { get; set; }
        public string? PhotoUrl { get; set; } = "https://api.dicebear.com/8.x/pixel-art/svg?seed=Unknown";
        public string? PhysicalDescription { get; set; }
        
        // Only essential Case info to display and for linking
        public int CaseId { get; set; }
        public string CaseNumber { get; set; }
        public string CaseTitle { get; set; }
    }
}
