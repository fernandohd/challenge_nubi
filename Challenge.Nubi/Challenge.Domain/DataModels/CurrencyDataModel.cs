using Challenge.Infrastructure.Data;
using Newtonsoft.Json;

namespace Challenge.Domain.DataModels
{
    public class CurrencyDataModel : DataModelBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("decimal_places")]
        public long DecimalPlaces { get; set; }
    }
}
