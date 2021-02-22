using System;
using Newtonsoft.Json;

namespace Challenge.Domain.DataModels
{
    public class ConversionDataModel
    {
        [JsonProperty("currency_base")]
        public string CurrencyBase { get; set; }

        [JsonProperty("currency_quote")]
        public string CurrencyQuote { get; set; }

        [JsonProperty("ratio")]
        public double Ratio { get; set; }

        [JsonProperty("rate")]
        public double Rate { get; set; }

        [JsonProperty("inv_rate")]
        public double InvRate { get; set; }

        [JsonProperty("creation_date")]
        public DateTime CreationDate { get; set; }

        [JsonProperty("valid_until")]
        public DateTime ValidUntil { get; set; }
    }
}
