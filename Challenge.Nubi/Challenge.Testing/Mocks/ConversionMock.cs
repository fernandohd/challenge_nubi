using Challenge.Domain.Entities;
using System;

namespace Challenge.Testing.Mocks
{
    public static class ConversionMock
    {
        public static ConversionEntity ConversionEntity()
        {
            return new ConversionEntity
            {
                CurrencyBase = "BTC",
                CurrencyQuote = "USD",
                Ratio = 51234.15498322,
                Rate = 51234.15498322,
                InvRate = 0.00001951,
                CreationDate = DateTime.Now,
                ValidUntil = DateTime.Now.AddYears(10),
            };
        }
    }
}
