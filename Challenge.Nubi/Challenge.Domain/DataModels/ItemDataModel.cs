using System;
using Newtonsoft.Json;
using Challenge.Infrastructure.Data;

namespace Challenge.Domain.DataModels
{
    public partial class ItemDataModel : DataModelBase
    {
        [JsonProperty("site_id", NullValueHandling = NullValueHandling.Ignore)]
        public string SiteId { get; set; }

        [JsonProperty("query", NullValueHandling = NullValueHandling.Ignore)]
        public string Query { get; set; }

        [JsonProperty("paging", NullValueHandling = NullValueHandling.Ignore)]
        public PagingDataModel Paging { get; set; }

        [JsonProperty("results", NullValueHandling = NullValueHandling.Ignore)]
        public ResultDataModel[] Results { get; set; }

        [JsonProperty("secondary_results", NullValueHandling = NullValueHandling.Ignore)]
        public ResultDataModel[] SecondaryResults { get; set; }

        [JsonProperty("related_results", NullValueHandling = NullValueHandling.Ignore)]
        public ResultDataModel[] RelatedResults { get; set; }

        [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
        public SortDataModel Sort { get; set; }

        [JsonProperty("available_sorts", NullValueHandling = NullValueHandling.Ignore)]
        public SortDataModel[] AvailableSorts { get; set; }

        [JsonProperty("filters", NullValueHandling = NullValueHandling.Ignore)]
        public FilterDataModel[] Filters { get; set; }

        [JsonProperty("available_filters", NullValueHandling = NullValueHandling.Ignore)]
        public AvailableFilterDataModel[] AvailableFilters { get; set; }
    }

    public partial class AvailableFilterDataModel
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("values", NullValueHandling = NullValueHandling.Ignore)]
        public AvailableFilterValueDataModel[] Values { get; set; }
    }

    public partial class AvailableFilterValueDataModel
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("results", NullValueHandling = NullValueHandling.Ignore)]
        public long? Results { get; set; }
    }

    public partial class SortDataModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }

    public partial class FilterDataModel
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("values", NullValueHandling = NullValueHandling.Ignore)]
        public FilterValueDataModel[] Values { get; set; }
    }

    public partial class FilterValueDataModel
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("path_from_root", NullValueHandling = NullValueHandling.Ignore)]
        public SortDataModel[] PathFromRoot { get; set; }
    }

    public partial class PagingDataModel
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

    public partial class ResultDataModel
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("site_id", NullValueHandling = NullValueHandling.Ignore)]
        public string SiteId { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("seller", NullValueHandling = NullValueHandling.Ignore)]
        public SellerDataModel Seller { get; set; }

        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public double? Price { get; set; }

        [JsonProperty("prices", NullValueHandling = NullValueHandling.Ignore)]
        public PricesDataModel Prices { get; set; }

        [JsonProperty("sale_price")]
        public PricesDataModel SalePrice { get; set; }

        [JsonProperty("currency_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CurrencyId { get; set; }

        [JsonProperty("available_quantity", NullValueHandling = NullValueHandling.Ignore)]
        public long? AvailableQuantity { get; set; }

        [JsonProperty("sold_quantity", NullValueHandling = NullValueHandling.Ignore)]
        public long? SoldQuantity { get; set; }

        [JsonProperty("buying_mode", NullValueHandling = NullValueHandling.Ignore)]
        public string BuyingMode { get; set; }

        [JsonProperty("listing_type_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ListingTypeId { get; set; }

        [JsonProperty("stop_time", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime StopTime { get; set; }

        [JsonProperty("condition", NullValueHandling = NullValueHandling.Ignore)]
        public string Condition { get; set; }

        [JsonProperty("permalink", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Permalink { get; set; }

        [JsonProperty("thumbnail", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Thumbnail { get; set; }

        [JsonProperty("thumbnail_id")]
        public string ThumbnailId { get; set; }

        [JsonProperty("accepts_mercadopago", NullValueHandling = NullValueHandling.Ignore)]
        public bool AcceptsMercadopago { get; set; }

        [JsonProperty("installments", NullValueHandling = NullValueHandling.Ignore)]
        public InstallmentsDataModel Installments { get; set; }

        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public AddressDataModel Address { get; set; }

        [JsonProperty("shipping", NullValueHandling = NullValueHandling.Ignore)]
        public ShippingDataModel Shipping { get; set; }

        [JsonProperty("seller_address", NullValueHandling = NullValueHandling.Ignore)]
        public SellerAddressDataModel SellerAddress { get; set; }

        [JsonProperty("attributes", NullValueHandling = NullValueHandling.Ignore)]
        public AttributeDataModel[] Attributes { get; set; }

        [JsonProperty("original_price")]
        public long? OriginalPrice { get; set; }

        [JsonProperty("category_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CategoryId { get; set; }

        [JsonProperty("official_store_id")]
        public long? OfficialStoreId { get; set; }

        [JsonProperty("domain_id", NullValueHandling = NullValueHandling.Ignore)]
        public string DomainId { get; set; }

        [JsonProperty("catalog_product_id")]
        public string CatalogProductId { get; set; }

        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Tags { get; set; }

        [JsonProperty("catalog_listing", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CatalogListing { get; set; }

        [JsonProperty("order_backend", NullValueHandling = NullValueHandling.Ignore)]
        public long? OrderBackend { get; set; }

        [JsonProperty("differential_pricing", NullValueHandling = NullValueHandling.Ignore)]
        public DifferentialPricingDataModel DifferentialPricing { get; set; }
    }

    public partial class AddressDataModel
    {
        [JsonProperty("state_id", NullValueHandling = NullValueHandling.Ignore)]
        public string StateId { get; set; }

        [JsonProperty("state_name", NullValueHandling = NullValueHandling.Ignore)]
        public string StateName { get; set; }

        [JsonProperty("city_id")]
        public string CityId { get; set; }

        [JsonProperty("city_name", NullValueHandling = NullValueHandling.Ignore)]
        public string CityName { get; set; }
    }

    public partial class AttributeDataModel
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("value_id")]
        public string ValueId { get; set; }

        [JsonProperty("value_name", NullValueHandling = NullValueHandling.Ignore)]
        public string ValueName { get; set; }

        [JsonProperty("value_struct")]
        public StructDataModel ValueStruct { get; set; }

        [JsonProperty("values", NullValueHandling = NullValueHandling.Ignore)]
        public AttributeValueDataModel[] Values { get; set; }

        [JsonProperty("attribute_group_id", NullValueHandling = NullValueHandling.Ignore)]
        public string AttributeGroupId { get; set; }

        [JsonProperty("attribute_group_name", NullValueHandling = NullValueHandling.Ignore)]
        public string AttributeGroupName { get; set; }

        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        public long? Source { get; set; }
    }

    public partial class StructDataModel
    {
        [JsonProperty("number", NullValueHandling = NullValueHandling.Ignore)]
        public long? Number { get; set; }

        [JsonProperty("unit", NullValueHandling = NullValueHandling.Ignore)]
        public string Unit { get; set; }
    }

    public partial class AttributeValueDataModel
    {
        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        public long? Source { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("struct")]
        public StructDataModel Struct { get; set; }
    }

    public partial class DifferentialPricingDataModel
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }
    }

    public partial class InstallmentsDataModel
    {
        [JsonProperty("quantity", NullValueHandling = NullValueHandling.Ignore)]
        public long? Quantity { get; set; }

        [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
        public double? Amount { get; set; }

        [JsonProperty("rate", NullValueHandling = NullValueHandling.Ignore)]
        public double? Rate { get; set; }

        [JsonProperty("currency_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CurrencyId { get; set; }
    }

    public partial class PricesDataModel
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("prices", NullValueHandling = NullValueHandling.Ignore)]
        public PriceDataModel[] PricesPrices { get; set; }

        [JsonProperty("presentation", NullValueHandling = NullValueHandling.Ignore)]
        public PresentationDataModel Presentation { get; set; }

        [JsonProperty("payment_method_prices", NullValueHandling = NullValueHandling.Ignore)]
        public object[] PaymentMethodPrices { get; set; }
    }

    public partial class PresentationDataModel
    {
        [JsonProperty("display_currency", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayCurrency { get; set; }
    }

    public partial class PriceDataModel
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("conditions", NullValueHandling = NullValueHandling.Ignore)]
        public ConditionsDataModel Conditions { get; set; }

        [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
        public double? Amount { get; set; }

        [JsonProperty("regular_amount")]
        public long? RegularAmount { get; set; }

        [JsonProperty("currency_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CurrencyId { get; set; }

        [JsonProperty("exchange_rate_context", NullValueHandling = NullValueHandling.Ignore)]
        public string ExchangeRateContext { get; set; }

        [JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
        public MetadataDataModel Metadata { get; set; }

        [JsonProperty("last_updated", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? LastUpdated { get; set; }
    }

    public partial class ConditionsDataModel
    {
        [JsonProperty("context_restrictions", NullValueHandling = NullValueHandling.Ignore)]
        public object[] ContextRestrictions { get; set; }

        [JsonProperty("start_time")]
        public DateTime? StartTime { get; set; }

        [JsonProperty("end_time")]
        public DateTime? EndTime { get; set; }

        [JsonProperty("eligible", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Eligible { get; set; }
    }

    public partial class MetadataDataModel
    {
        [JsonProperty("campaign_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CampaignId { get; set; }

        [JsonProperty("promotion_id", NullValueHandling = NullValueHandling.Ignore)]
        public string PromotionId { get; set; }

        [JsonProperty("promotion_type", NullValueHandling = NullValueHandling.Ignore)]
        public string PromotionType { get; set; }
    }

    public partial class SellerDataModel
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("permalink", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Permalink { get; set; }

        [JsonProperty("registration_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? RegistrationDate { get; set; }

        [JsonProperty("car_dealer", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CarDealer { get; set; }

        [JsonProperty("real_estate_agency", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RealEstateAgency { get; set; }

        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Tags { get; set; }

        [JsonProperty("seller_reputation", NullValueHandling = NullValueHandling.Ignore)]
        public SellerReputationDataModel SellerReputation { get; set; }

        [JsonProperty("eshop", NullValueHandling = NullValueHandling.Ignore)]
        public EshopDataModel Eshop { get; set; }
    }

    public partial class EshopDataModel
    {
        [JsonProperty("nick_name", NullValueHandling = NullValueHandling.Ignore)]
        public string NickName { get; set; }

        [JsonProperty("eshop_rubro")]
        public object EshopRubro { get; set; }

        [JsonProperty("eshop_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? EshopId { get; set; }

        [JsonProperty("eshop_locations", NullValueHandling = NullValueHandling.Ignore)]
        public object[] EshopLocations { get; set; }

        [JsonProperty("site_id", NullValueHandling = NullValueHandling.Ignore)]
        public string SiteId { get; set; }

        [JsonProperty("eshop_logo_url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri EshopLogoUrl { get; set; }

        [JsonProperty("eshop_status_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? EshopStatusId { get; set; }

        [JsonProperty("seller", NullValueHandling = NullValueHandling.Ignore)]
        public long? Seller { get; set; }

        [JsonProperty("eshop_experience", NullValueHandling = NullValueHandling.Ignore)]
        public long? EshopExperience { get; set; }
    }

    public partial class SellerReputationDataModel
    {
        [JsonProperty("transactions", NullValueHandling = NullValueHandling.Ignore)]
        public TransactionsDataModel Transactions { get; set; }

        [JsonProperty("power_seller_status")]
        public string PowerSellerStatus { get; set; }

        [JsonProperty("metrics", NullValueHandling = NullValueHandling.Ignore)]
        public MetricsDataModel Metrics { get; set; }

        [JsonProperty("level_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LevelId { get; set; }

        [JsonProperty("protection_end_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ProtectionEndDate { get; set; }

        [JsonProperty("real_level", NullValueHandling = NullValueHandling.Ignore)]
        public string RealLevel { get; set; }
    }

    public partial class MetricsDataModel
    {
        [JsonProperty("claims", NullValueHandling = NullValueHandling.Ignore)]
        public MetricDataModel Claims { get; set; }

        [JsonProperty("delayed_handling_time", NullValueHandling = NullValueHandling.Ignore)]
        public MetricDataModel DelayedHandlingTime { get; set; }

        [JsonProperty("sales", NullValueHandling = NullValueHandling.Ignore)]
        public SalesDataModel Sales { get; set; }

        [JsonProperty("cancellations", NullValueHandling = NullValueHandling.Ignore)]
        public MetricDataModel Cancellations { get; set; }
    }

    public partial class MetricDataModel
    {
        [JsonProperty("rate", NullValueHandling = NullValueHandling.Ignore)]
        public double? Rate { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public long? Value { get; set; }

        [JsonProperty("period", NullValueHandling = NullValueHandling.Ignore)]
        public string Period { get; set; }

        [JsonProperty("excluded", NullValueHandling = NullValueHandling.Ignore)]
        public ExcludedDataModel Excluded { get; set; }
    }

    public partial class ExcludedDataModel
    {
        [JsonProperty("real_rate", NullValueHandling = NullValueHandling.Ignore)]
        public double? RealRate { get; set; }

        [JsonProperty("real_value", NullValueHandling = NullValueHandling.Ignore)]
        public long? RealValue { get; set; }
    }

    public partial class SalesDataModel
    {
        [JsonProperty("period", NullValueHandling = NullValueHandling.Ignore)]
        public string Period { get; set; }

        [JsonProperty("completed", NullValueHandling = NullValueHandling.Ignore)]
        public long? Completed { get; set; }
    }

    public partial class TransactionsDataModel
    {
        [JsonProperty("total", NullValueHandling = NullValueHandling.Ignore)]
        public long? Total { get; set; }

        [JsonProperty("canceled", NullValueHandling = NullValueHandling.Ignore)]
        public long? Canceled { get; set; }

        [JsonProperty("period", NullValueHandling = NullValueHandling.Ignore)]
        public string Period { get; set; }

        [JsonProperty("ratings", NullValueHandling = NullValueHandling.Ignore)]
        public RatingsDataModel Ratings { get; set; }

        [JsonProperty("completed", NullValueHandling = NullValueHandling.Ignore)]
        public long? Completed { get; set; }
    }

    public partial class RatingsDataModel
    {
        [JsonProperty("negative", NullValueHandling = NullValueHandling.Ignore)]
        public double? Negative { get; set; }

        [JsonProperty("positive", NullValueHandling = NullValueHandling.Ignore)]
        public double? Positive { get; set; }

        [JsonProperty("neutral", NullValueHandling = NullValueHandling.Ignore)]
        public double? Neutral { get; set; }
    }

    public partial class SellerAddressDataModel
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("comment", NullValueHandling = NullValueHandling.Ignore)]
        public string Comment { get; set; }

        [JsonProperty("address_line", NullValueHandling = NullValueHandling.Ignore)]
        public string AddressLine { get; set; }

        [JsonProperty("zip_code", NullValueHandling = NullValueHandling.Ignore)]
        public string ZipCode { get; set; }

        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public SortDataModel Country { get; set; }

        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public SortDataModel State { get; set; }

        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        public SortDataModel City { get; set; }

        [JsonProperty("latitude", NullValueHandling = NullValueHandling.Ignore)]
        public string Latitude { get; set; }

        [JsonProperty("longitude", NullValueHandling = NullValueHandling.Ignore)]
        public string Longitude { get; set; }
    }

    public partial class ShippingDataModel
    {
        [JsonProperty("free_shipping", NullValueHandling = NullValueHandling.Ignore)]
        public bool? FreeShipping { get; set; }

        [JsonProperty("mode", NullValueHandling = NullValueHandling.Ignore)]
        public string Mode { get; set; }

        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Tags { get; set; }

        [JsonProperty("logistic_type", NullValueHandling = NullValueHandling.Ignore)]
        public string LogisticType { get; set; }

        [JsonProperty("store_pick_up", NullValueHandling = NullValueHandling.Ignore)]
        public bool? StorePickUp { get; set; }
    }

}
