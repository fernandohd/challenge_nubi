using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Challenge.Application.Models;
using Challenge.Application.Services.ApiServices;

namespace Challenge.Application.Handlers
{
    public class ObtenerPaisesRequest : IRequest<IEnumerable<PaisModel>> { }

    public class ObtenerPaisesHandler : IRequestHandler<ObtenerPaisesRequest, IEnumerable<PaisModel>>
    {
        public ObtenerPaisesHandler(ILogger<ObtenerPaisesHandler> logger, IPaisesApiService service, IMapper mapper)
        {
            this.logger = logger;
            this.service = service;
            this.mapper = mapper;
        }

        private readonly ILogger<ObtenerPaisesHandler> logger;
        private readonly IPaisesApiService service;
        private readonly IMapper mapper;

        public async Task<IEnumerable<PaisModel>> Handle(ObtenerPaisesRequest request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Obteniendo paises");

            var dataModel = await service.ObtenerPaisesAsync();

            return mapper.Map<IEnumerable<PaisModel>>(dataModel);
        }
    }
}
