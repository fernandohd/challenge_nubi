using Challenge.Domain.Entities;

namespace Challenge.Testing.Mocks
{
    public static class CurrencyHistoryMock
    {
        public static CurrencyHistoryEntity CurrencyHistoryEntity()
        {
            return new CurrencyHistoryEntity
            {
                CurrencyId = "BTC",
                Symbol = "B",
                Description = "Moneda de testing",
                DecimalPlaces = 8,
                Conversion = ConversionMock.ConversionEntity(),
            };
        }
    }
}
