using Newtonsoft.Json;

namespace Challenge.Application.Models
{
    public class CurrencyModel
    {
        [JsonProperty("id")]
        public string CurrencyId { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("decimal_places")]
        public long DecimalPlaces { get; set; }

        [JsonProperty("todolar")]
        public ConversionModel Conversion { get; set; }
    }
}
