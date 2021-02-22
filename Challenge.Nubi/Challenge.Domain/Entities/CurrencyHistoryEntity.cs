using Challenge.Infrastructure.Data;

namespace Challenge.Domain.Entities
{
    public class CurrencyHistoryEntity : EntityBase
    {
        public string CurrencyId { get; set; }

        public string Symbol { get; set; }

        public string Description { get; set; }

        public long DecimalPlaces { get; set; }

        public int? ToDolar { get; set; }

        public virtual ConversionEntity Conversion { get; set; }
    }
}
