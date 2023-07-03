using CloudRepublic.DevOps.ServerUI.Data.Models;
using Microsoft.Azure.Pipelines.WebApi;
using Microsoft.TeamFoundation.Build.WebApi;
using Microsoft.TeamFoundation.SourceControl.WebApi;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using Pipeline = CloudRepublic.DevOps.ServerUI.Data.Models.Pipeline;

namespace CloudRepublic.DevOps.ServerUI.Data
{
    public class AzureDevOpsService
    {
        private readonly string projectName;
        private readonly VssConnection connection;

        public AzureDevOpsService(string organizationName, string projectName, string patToken)
        {
            var orgUrl = new Uri($"https://dev.azure.com/{organizationName}");
            this.projectName = projectName;
            connection = new VssConnection(orgUrl, new VssBasicCredential(string.Empty, patToken));
        }

        public async Task<IEnumerable<Pipeline>> GetPipelinesAsync()
        {
            var buildClient = connection.GetClient<BuildHttpClient>();
            var pipelines = await buildClient.GetDefinitionsAsync(projectName);
            return pipelines.Select(x => new Pipeline
            {
                PipelineId = x.Id,
                Name = x.Name
            });
        }

        public async Task<IEnumerable<PipelineRun>> GetPipelineRunsAsync(int pipelineId)
        {
            var buildClient = connection.GetClient<BuildHttpClient>();
            //, top: 20
            var runs = await buildClient.GetBuildsAsync(projectName, definitions: new[] { pipelineId }, queryOrder: BuildQueryOrder.StartTimeDescending);
            await Console.Out.WriteLineAsync(runs.Count.ToString());
            //var timeLine = await GetTimelineForRunAsync(pipelineId);
            //await Console.Out.WriteLineAsync(timeLine.Records.Count.ToString());

            List<PipelineRun> result = new List<PipelineRun>();
            foreach (var run in runs)
            {
                string commitMessage = string.Empty;
                if (!string.IsNullOrEmpty(run.Repository.Name))
                {
                    commitMessage = await GetCommitMessageAsync(run.Repository.Id, run.SourceVersion);
                }

                result.Add(new PipelineRun()
                {
                    BuildNumber = run.BuildNumber,
                    Name = commitMessage,
                    Status = run.Status,
                    StartTime = run.StartTime,
                    FinishTime = run.FinishTime,
                    Reason = run.Reason
                });
            }
            return result;
        }

        public async Task<Timeline> GetTimelineForRunAsync(int buildId)
        {
            var buildClient = connection.GetClient<BuildHttpClient>();
            var timeline = await buildClient.GetBuildTimelineAsync(projectName, buildId);

            foreach (var record in timeline.Records.Where(x => x.RecordType == "Stage"))
            {
                Console.WriteLine($"Stage: {record.Name}, Status: {record.Result}");
            }
            return timeline;
        }

        private async Task<string> GetCommitMessageAsync(string repositoryId, string commitId)
        {
            GitHttpClient gitClient = connection.GetClient<GitHttpClient>();
            GitCommit commit = await gitClient.GetCommitAsync(projectName, commitId, repositoryId);
            return commit.Comment;
        }
    }
}