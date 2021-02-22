using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Challenge.Application.Models;
using Challenge.Application.Services.ApiServices;
using System.Text;
using Challenge.Application.Services;

namespace Challenge.Application.Handlers
{
    public class ObtenerConversionRequest : IRequest<ConversionModel>
    {
        public ObtenerConversionRequest(string from, string to)
        {
            From = from;
            To = to;
        }

        public string From { get; }
        public string To { get; }
    }

    public class ObtenerConversionHandler : IRequestHandler<ObtenerConversionRequest, ConversionModel>
    {
        private readonly ILogger<ObtenerConversionHandler> logger;
        private readonly IMonedasApiService service;
        private readonly ICsvLoggingService loggingService;
        private readonly IMapper mapper;

        public ObtenerConversionHandler(ILogger<ObtenerConversionHandler> logger, IMonedasApiService service, ICsvLoggingService loggingService, IMapper mapper)
        {
            this.logger = logger;
            this.service = service;
            this.loggingService = loggingService;
            this.mapper = mapper;
        }

        public async Task<ConversionModel> Handle(ObtenerConversionRequest request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Obtener conversion de: {from} a {to}", request.From, request.To);

            var result = await service.ObtenerConversionAsync(request.From, request.To);

            await loggingService.WriteLine(result.Ratio.ToString());

            return mapper.Map<ConversionModel>(result);
        }

    }
}
