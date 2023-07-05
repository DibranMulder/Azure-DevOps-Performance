using Newtonsoft.Json.Linq;

namespace CloudRepublic.DevOps.ServerUI.Data.Models.Azure
{
    public class ListResponse<T>
    {
        public IEnumerable<T>? Value { get; set; }
        public Count? Count { get; set; }
    }
}
