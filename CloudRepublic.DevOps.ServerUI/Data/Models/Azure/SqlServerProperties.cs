namespace CloudRepublic.DevOps.ServerUI.Data.Models.Azure
{
    public class SqlServerProperties
    {
        public string AdministratorLogin { get; set; }
        public string Version { get; set; }
        public string State { get; set; }
        public string FullyQualifiedDomainName { get; set; }
        public object[] PrivateEndpointConnections { get; set; }
        public string MinimalTlsVersion { get; set; }
        public string PublicNetworkAccess { get; set; }
        public string RestrictOutboundNetworkAccess { get; set; }
    }
}
