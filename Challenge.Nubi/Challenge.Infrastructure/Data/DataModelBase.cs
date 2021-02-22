using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Challenge.Infrastructure.Data
{
    public class DataModelBase
    {
        public DataModelBase() { }

        public string ToJson() => JsonConvert.SerializeObject(this);

        public StringContent Serialize() => new StringContent(ToJson(), Encoding.UTF8, "application/json");
    }
}
