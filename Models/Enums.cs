using System.ComponentModel.DataAnnotations;

namespace DetectiveCaseFileSystem.Models
{
    public enum CrimeType
    {
        [Display(Name = "First Degree Murder")]
        FirstDegreeMurder,
        Arson,
        Blackmail,
        Kidnapping,
        [Display(Name = "Grand Theft")]
        GrandTheft,
        Fraud
    }
    public enum PriorityLevel
    {
        Routine,
        Elevated,
        High,
        Critical,
        [Display(Name = "Top Secret")]
        TopSecret
    }
    public enum Status
    {
        Open,
        [Display(Name = "Under Investigation")]
        UnderInvestigation,
        [Display(Name = "Awaiting Evidence")]
        AwaitingEvidence,
        Cold,
        [Display(Name = "Pending Trial")]
        PendingTrial,
        Closed
    }
    public enum RoleInCase
    {
        [Display(Name = "Person of Interest")]
        PersonOfInterest,
        [Display(Name = "Primary Suspect")]
        PrimarySuspect,
        Accomplice,
        Witness,
        Victim,
        Informant
    }
    public enum RiskLevel
    {
        None,
        Low,
        Medium,
        High,
        Extreme,
        [Display(Name = "Flight Risk")]
        FlightRisk,
        [Display(Name = "Armed and Dangerous")]
        ArmedAndDangerous
    }
}
