namespace CloudRepublic.DevOps.ServerUI.Data.Models.Azure
{
    public class AppServicePlanProperties
    {
        public long ServerFarmId { get; set; }
        public string Name { get; set; }
        public long WorkerSize { get; set; }
        public long WorkerSizeId { get; set; }
        public object WorkerTierName { get; set; }
        public long NumberOfWorkers { get; set; }
        public object CurrentWorkerSize { get; set; }
        public object CurrentWorkerSizeId { get; set; }
        public object CurrentNumberOfWorkers { get; set; }
        public string Status { get; set; }
        public string WebSpace { get; set; }
        public object Subscription { get; set; }
        public object AdminSiteName { get; set; }
        public object HostingEnvironment { get; set; }
        public object HostingEnvironmentProfile { get; set; }
        public long MaximumNumberOfWorkers { get; set; }
        public string PlanName { get; set; }
        public object AdminRuntimeSiteName { get; set; }
        public string ComputeMode { get; set; }
        public object SiteMode { get; set; }
        public string GeoRegion { get; set; }
        public object PerSiteScaling { get; set; }
        public object ElasticScaleEnabled { get; set; }
        public object MaximumElasticWorkerCount { get; set; }
        public long NumberOfSites { get; set; }
        public object HostingEnvironmentId { get; set; }
        public object IsSpot { get; set; }
        public object SpotExpirationTime { get; set; }
        public object FreeOfferExpirationTime { get; set; }
        public object Tags { get; set; }
        public string Kind { get; set; }
        public string ResourceGroup { get; set; }
        public object Reserved { get; set; }
        public object IsXenon { get; set; }
        public object HyperV { get; set; }
        public object MdmId { get; set; }
        public object TargetWorkerCount { get; set; }
        public object TargetWorkerSizeId { get; set; }
        public object ProvisioningState { get; set; }
        public object WebSiteId { get; set; }
        public object ExistingServerFarmIds { get; set; }
        public object KubeEnvironmentProfile { get; set; }
        public object ZoneRedundant { get; set; }
    }
}