using System.ComponentModel.DataAnnotations;

namespace DetectiveCaseFileSystem.Models
{
    public class Case
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Case number is required.")]
        [Display(Name = "Case Number")]
        public string CaseNumber { get; set; }

        [Required(ErrorMessage = "Case title is required.")]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "Type of crime is required.")]
        [Display(Name = "Crime Type")]
        public CrimeType CrimeType { get; set; }

        [Required(ErrorMessage = "Priority level is required.")]
        [Display(Name = "Priority Level")]
        public PriorityLevel PriorityLevel { get; set; }

        [Required(ErrorMessage = "Crime location is required.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Case status is required.")]
        public Status Status { get; set; }

        [Display(Name = "Time Of Crime")]
        public DateTime? TimeOfCrime { get; set; }

        [Required(ErrorMessage = "Name of investigator is required.")]
        [Display(Name = "Investigator Name")]
        public string Investigator { get; set; }
    }
}
