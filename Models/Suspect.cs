using System.ComponentModel.DataAnnotations;

namespace DetectiveCaseFileSystem.Models
{
    public class Suspect
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Suspect name is required.")]
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? KnownAssociates { get; set; }
        [Required(ErrorMessage = "Risk level must be specified.")]
        public RiskLevel RiskLevel { get; set; }
        public string? LastKnownLocation { get; set; } = "Location Unknown";
        public string? Aliases { get; set; } = "Unknown";
        [Required(ErrorMessage = "Role in case must be specified.")]
        public RoleInCase RoleInCase { get; set; }
        // Backing field
        private string? _photoUrl;
        public string? PhotoUrl 
        { 
            get => string.IsNullOrEmpty(_photoUrl) ? $"https://api.dicebear.com/8.x/pixel-art/svg?seed={Name}" : _photoUrl; 
            set => _photoUrl = value; 
        }
        public string? PhysicalDescription { get; set; }
        [Required(ErrorMessage = "Associated case file is required.")]
        public int? CaseId { get; set; }
    }
}
