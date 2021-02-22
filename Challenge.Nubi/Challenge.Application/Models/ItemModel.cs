using System;
using Newtonsoft.Json;

namespace Challenge.Application.Models
{
    public partial class ItemModel
    {
        [JsonProperty("site_id", NullValueHandling = NullValueHandling.Ignore)]
        public string SiteId { get; set; }

        [JsonProperty("query", NullValueHandling = NullValueHandling.Ignore)]
        public string Query { get; set; }

        [JsonProperty("paging", NullValueHandling = NullValueHandling.Ignore)]
        public PagingModel Paging { get; set; }

        [JsonProperty("results", NullValueHandling = NullValueHandling.Ignore)]
        public ResultModel[] Results { get; set; }

        [JsonProperty("secondary_results", NullValueHandling = NullValueHandling.Ignore)]
        public ResultModel[] SecondaryResults { get; set; }

        [JsonProperty("related_results", NullValueHandling = NullValueHandling.Ignore)]
        public ResultModel[] RelatedResults { get; set; }

        [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
        public SortModel Sort { get; set; }

        [JsonProperty("available_sorts", NullValueHandling = NullValueHandling.Ignore)]
        public SortModel[] AvailableSorts { get; set; }

        [JsonProperty("filters", NullValueHandling = NullValueHandling.Ignore)]
        public FilterModel[] Filters { get; set; }

        [JsonProperty("available_filters", NullValueHandling = NullValueHandling.Ignore)]
        public AvailableFilterModel[] AvailableFilters { get; set; }
    }

    public partial class AvailableFilterModel
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("values", NullValueHandling = NullValueHandling.Ignore)]
        public AvailableFilterValueModel[] Values { get; set; }
    }

    public partial class AvailableFilterValueModel
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("results", NullValueHandling = NullValueHandling.Ignore)]
        public long? Results { get; set; }
    }

    public partial class SortModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }

    public partial class FilterModel
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("values", NullValueHandling = NullValueHandling.Ignore)]
        public FilterValueModel[] Values { get; set; }
    }

    public partial class FilterValueModel
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("path_from_root", NullValueHandling = NullValueHandling.Ignore)]
        public SortModel[] PathFromRoot { get; set; }
    }

    public partial class PagingModel
    {
        [JsonProperty("total", NullValueHandling = NullValueHandling.Ignore)]
        public long? Total { get; set; }

        [JsonProperty("primary_results", NullValueHandling = NullValueHandling.Ignore)]
        public long? PrimaryResults { get; set; }

        [JsonProperty("offset", NullValueHandling = NullValueHandling.Ignore)]
        public long? Offset { get; set; }

        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public long? Limit { get; set; }
    }

    public partial class ResultModel
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("site_id", NullValueHandling = NullValueHandling.Ignore)]
        public string SiteId { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public double? Price { get; set; }

        [JsonProperty("seller_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? SellerId { get; set; }

        [JsonProperty("permalink", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Permalink { get; set; }
    }

}
