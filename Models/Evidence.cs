namespace DetectiveCaseFileSystem.Models
{
    public class Evidence
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string? Description { get; set; }
        public DateTime DateCollected { get; set; }
        public string LocationFound { get; set; }
        public string? ImageUrl { get; set; }
        public int CaseId { get; set; }
        public int? SuspectId { get; set; }
    }
}
