using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Challenge.Domain.Entities;
using Microsoft.Extensions.Logging;
using Challenge.Application.Models;
using Challenge.Application.Services;
using Challenge.Application.Services.ApiServices;
using Challenge.Application.Services.DbServices;

namespace Challenge.Application.Handlers
{
    public class ObtenerMonedasRequest : IRequest<IEnumerable<CurrencyModel>> { }

    public class ObtenerMonedasHandler : IRequestHandler<ObtenerMonedasRequest, IEnumerable<CurrencyModel>>
    {
        private readonly ILogger<ObtenerMonedasHandler> logger;
        private readonly IMonedasApiService monedasApiService;
        private readonly ICsvLoggingService loggingService;
        private readonly ICurrencyHistoryDbService currencyHistoryDbService;
        private readonly IMapper mapper;

        public ObtenerMonedasHandler(ILogger<ObtenerMonedasHandler> logger,
            IMonedasApiService monedasApiService,
            ICsvLoggingService loggingService,
            ICurrencyHistoryDbService currencyHistoryDbService,
            IMapper mapper)
        {
            this.logger = logger;
            this.monedasApiService = monedasApiService;
            this.loggingService = loggingService;
            this.currencyHistoryDbService = currencyHistoryDbService;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CurrencyModel>> Handle(ObtenerMonedasRequest request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Obtener todas las monedas");

            var dataModels = await monedasApiService.ObtenerMonedasAsync();

            var models = await ObtenerConversiones(mapper.Map<IEnumerable<CurrencyModel>>(dataModels));

            var entities = mapper.Map<IEnumerable<CurrencyHistoryEntity>>(models);

            await currencyHistoryDbService.InsertarRangoCurrencyHistoryAsync(entities);

            return models;
        }

        public async Task<IEnumerable<CurrencyModel>> ObtenerConversiones(IEnumerable<CurrencyModel> currencies)
        {
            string idDolar = "USD";

            foreach (var currency in currencies)
            {
                try
                {
                    var conversionDataModel = await monedasApiService.ObtenerConversionAsync(currency.CurrencyId, idDolar);

                    await loggingService.WriteLine(conversionDataModel.Ratio.ToString());

                    currency.Conversion = mapper.Map<ConversionModel>(conversionDataModel);
                }
                catch
                {
                    currency.Conversion = null;
                }
            }

            return currencies;
        }
    }
}
