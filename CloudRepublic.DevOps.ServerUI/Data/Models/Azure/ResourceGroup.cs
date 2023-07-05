namespace CloudRepublic.DevOps.ServerUI.Data.Models.Azure
{
    public class ResourceGroup
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Location Location { get; set; }
        public Properties Properties { get; set; }
        public Tags Tags { get; set; }
    }

    public enum Location { Eastus, Northeurope, Westeurope };

    public enum ProvisioningState { Succeeded };

    public partial class Properties
    {
        public ProvisioningState ProvisioningState { get; set; }
    }
}