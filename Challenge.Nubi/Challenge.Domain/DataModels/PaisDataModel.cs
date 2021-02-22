using Challenge.Infrastructure.Data;
using Newtonsoft.Json;

namespace Challenge.Domain.DataModels
{
    public partial class PaisDataModel : DataModelBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("currency_id")]
        public string CurrencyId { get; set; }

        [JsonProperty("decimal_separator")]
        public string DecimalSeparator { get; set; }

        [JsonProperty("thousands_separator")]
        public string ThousandsSeparator { get; set; }

        [JsonProperty("time_zone")]
        public string TimeZone { get; set; }

        [JsonProperty("geo_information")]
        public GeoInformationDataModel GeoInformation { get; set; }

        [JsonProperty("states")]
        public StateDataModel[] States { get; set; }
    }

    public partial class GeoInformationDataModel
    {
        [JsonProperty("location")]
        public LocationDataModel Location { get; set; }
    }

    public partial class LocationDataModel
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }

    public partial class StateDataModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
