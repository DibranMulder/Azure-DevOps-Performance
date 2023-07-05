namespace CloudRepublic.DevOps.ServerUI.Data.Models.Azure
{
    public class Sku
    {
        public string Name { get; set; }
        public string Tier { get; set; }
        public string Size { get; set; }
        public string Family { get; set; }
        public long Capacity { get; set; }
    }
}
