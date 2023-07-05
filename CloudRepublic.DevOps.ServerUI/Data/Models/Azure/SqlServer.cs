namespace CloudRepublic.DevOps.ServerUI.Data.Models.Azure
{
    public class SqlServer
    {
        public string Kind { get; set; }
        public SqlServerProperties Properties { get; set; }
        public string Location { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Tags Tags { get; set; }
    }
}
