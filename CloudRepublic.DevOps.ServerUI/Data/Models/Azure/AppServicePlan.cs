namespace CloudRepublic.DevOps.ServerUI.Data.Models.Azure
{
    public class AppServicePlan
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public TypeEnum Type { get; set; }
        public Kind Kind { get; set; }
        public Ion Location { get; set; }
        public Properties Properties { get; set; }
        public Sku Sku { get; set; }
    }
}
