namespace CloudRepublic.DevOps.ServerUI.Data.Models.Azure
{
    public class AppServicePlan
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Kind { get; set; }
        public string Location { get; set; }
        public Properties Properties { get; set; }
        public Sku Sku { get; set; }
    }
}
