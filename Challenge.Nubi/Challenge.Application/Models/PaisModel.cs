using Newtonsoft.Json;

namespace Challenge.Application.Models
{
    public partial class PaisModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("currency_id")]
        public string CurrencyId { get; set; }

        [JsonProperty("decimal_separator", NullValueHandling = NullValueHandling.Ignore)]
        public string DecimalSeparator { get; set; }

        [JsonProperty("thousands_separator", NullValueHandling = NullValueHandling.Ignore)]
        public string ThousandsSeparator { get; set; }

        [JsonProperty("time_zone", NullValueHandling = NullValueHandling.Ignore)]
        public string TimeZone { get; set; }

        [JsonProperty("geo_information", NullValueHandling = NullValueHandling.Ignore)]
        public GeoInformationModel GeoInformation { get; set; }

        [JsonProperty("states", NullValueHandling = NullValueHandling.Ignore)]
        public StateModel[] States { get; set; }
    }

    public partial class GeoInformationModel
    {
        [JsonProperty("location")]
        public LocationModel Location { get; set; }
    }

    public partial class LocationModel
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }

    public partial class StateModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
