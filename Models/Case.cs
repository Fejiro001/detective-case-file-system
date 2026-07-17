using System.ComponentModel.DataAnnotations;

namespace DetectiveCaseFileSystem.Models
{
    public class Case
    {
        public int Id { get; set; }
        public string CaseNumber { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public CrimeType CrimeType { get; set; }
        public PriorityLevel PriorityLevel { get; set; }
        public string Location { get; set; }
        public Status Status { get; set; }
        public DateTime? TimeOfCrime { get; set; }
        public string Investigator { get; set; }
    }
}
