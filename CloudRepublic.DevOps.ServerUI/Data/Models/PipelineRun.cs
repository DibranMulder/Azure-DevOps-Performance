using Microsoft.TeamFoundation.Build.WebApi;

namespace CloudRepublic.DevOps.ServerUI.Data.Models
{
    public class PipelineRun
    {
        public string BuildNumber { get; set; }
        public string Name { get; set; }
        public BuildStatus? Status { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public BuildReason Reason { get; internal set; }
    }
}
