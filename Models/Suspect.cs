namespace DetectiveCaseFileSystem.Models
{
    public class Suspect
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? KnownAssociates { get; set; }
        public RiskLevel RiskLevel { get; set; }
        public string? LastKnownLocation { get; set; } = "Location Unknown";
        public string? Aliases { get; set; } = "Unknown";
        public RoleInCase RoleInCase { get; set; }
        public string? PhotoUrl { get; set; } = "https://api.dicebear.com/8.x/pixel-art/svg?seed=Unknown";
        public string? PhysicalDescription { get; set; }
        public int CaseId { get; set; }
    }
}
