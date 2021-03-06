using System;

namespace IncidentTrackerModal
{
    public class IncidentTracker
    {
        public int IncidentTrackerId { get; set; }
        public string IncidentId { get; set; }
        public string Description { get; set; }
        public Severity Severity { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Status Status { get; set; }
    }
    public enum Status
    {
        Notstarted,
        Pending,
        Started,
        Completed,
        Failed
    }
    public enum Severity
    {
        High,
        Low,
        Medium
    }
}
