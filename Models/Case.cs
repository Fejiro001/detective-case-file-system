using System.ComponentModel.DataAnnotations;

namespace DetectiveCaseFileSystem.Models
{
    public class Case
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Case number is required.")]
        public string CaseNumber { get; set; }

        [Required(ErrorMessage = "Case title is required.")]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "Type of crime is required.")]
        public CrimeType CrimeType { get; set; }

        [Required(ErrorMessage = "Priority level is required.")]
        public PriorityLevel PriorityLevel { get; set; }

        [Required(ErrorMessage = "Crime location is required.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Case status is required.")]
        public Status Status { get; set; }

        public DateTime? TimeOfCrime { get; set; }

        [Required(ErrorMessage = "Name of investigator is required.")]
        public string Investigator { get; set; }
    }
}
