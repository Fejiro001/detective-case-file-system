using System.ComponentModel.DataAnnotations;

namespace DetectiveCaseFileSystem.Models
{
    public class Evidence
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Evidence type is required.")]
        public string Type { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "Date collected is required.")]
        [Display(Name = "Date Collected")]
        public DateTime DateCollected { get; set; }
        [Required(ErrorMessage = "Location found is required.")]
        [Display(Name = "Location Found")]
        public string LocationFound { get; set; }
        public string? ImageUrl { get; set; } = "https://placehold.co/400x300?text=No+Image";
        [Required(ErrorMessage = "Associated case file is required.")]
        [Display(Name = "Associated Case File")]
        public int? CaseId { get; set; }
        [Display(Name = "Associated Suspect (Optional)")]
        public int? SuspectId { get; set; }
    }
}
