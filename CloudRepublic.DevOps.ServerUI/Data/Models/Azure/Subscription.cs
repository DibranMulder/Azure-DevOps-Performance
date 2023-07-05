namespace CloudRepublic.DevOps.ServerUI.Data.Models.Azure
{
    public class Subscription
    {
        public string Id { get; set; }
        public string AuthorizationSource { get; set; }
        public object[] ManagedByTenants { get; set; }
        public Guid SubscriptionId { get; set; }
        public Guid TenantId { get; set; }
        public string DisplayName { get; set; }
        public string State { get; set; }
        public SubscriptionPolicies SubscriptionPolicies { get; set; }
    }
}
