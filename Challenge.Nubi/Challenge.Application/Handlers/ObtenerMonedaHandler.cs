using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Challenge.Domain.Entities;
using Microsoft.Extensions.Logging;
using Challenge.Application.Models;
using Challenge.Application.Services;
using Challenge.Application.Services.ApiServices;
using Challenge.Application.Services.DbServices;

namespace Challenge.Application.Handlers
{
    public class ObtenerMonedaRequest : IRequest<CurrencyModel>
    {
        public ObtenerMonedaRequest(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }

    public class ObtenerMonedaHandler : IRequestHandler<ObtenerMonedaRequest, CurrencyModel>
    {
        private readonly ILogger<ObtenerMonedaHandler> logger;
        private readonly IMonedasApiService monedasApiService;
        private readonly ICsvLoggingService loggingService;
        private readonly ICurrencyHistoryDbService currencyHistoryDbService;
        private readonly IMapper mapper;

        public ObtenerMonedaHandler(ILogger<ObtenerMonedaHandler> logger,
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

        public async Task<CurrencyModel> Handle(ObtenerMonedaRequest request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Obtener moneda {id}", request.Id.ToUpper());

            var dataModel = await monedasApiService.ObtenerMonedaAsync(request.Id.ToUpper());

            var model = await ObtenerConversion(mapper.Map<CurrencyModel>(dataModel));

            var entity = mapper.Map<CurrencyHistoryEntity>(model);

            await currencyHistoryDbService.InsertarCurrencyHistoryAsync(entity);

            return model;
        }

        public async Task<CurrencyModel> ObtenerConversion(CurrencyModel currency)
        {
            string idDolar = "USD";

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

            return currency;
        }
    }
}