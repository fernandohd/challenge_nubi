using Challenge.Infrastructure.Data;
using System;

namespace Challenge.Domain.Entities
{
    public class ConversionEntity : EntityBase
    {
        public string CurrencyBase { get; set; }

        public string CurrencyQuote { get; set; }

        public double Ratio { get; set; }

        public double Rate { get; set; }

        public double InvRate { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ValidUntil { get; set; }

        public virtual CurrencyHistoryEntity CurrencyHistory { get; set; }
    }
}
