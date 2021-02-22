using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Challenge.Application.Models;
using Challenge.Application.Services.ApiServices;
using Challenge.Infrastructure.Exceptions;

namespace Challenge.Application.Handlers
{
    public class ObtenerItemRequest : IRequest<ItemModel>
    {
        public ObtenerItemRequest(string termino)
        {
            Termino = termino;
        }

        public string Termino { get; }
    }

    public class ObtenerItemHandler : IRequestHandler<ObtenerItemRequest, ItemModel>
    {
        public ObtenerItemHandler(ILogger<ObtenerItemHandler> logger, IBusquedaApiService service, IMapper mapper)
        {
            this.logger = logger;
            this.service = service;
            this.mapper = mapper;
        }

        private readonly ILogger<ObtenerItemHandler> logger;
        private readonly IBusquedaApiService service;
        private readonly IMapper mapper;

        public async Task<ItemModel> Handle(ObtenerItemRequest request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Obteniendo item por termino {termino}", request.Termino);

            if (string.IsNullOrWhiteSpace(request.Termino))
            {
                throw new BadRequestProjectException("Invalid search param");
            }

            var dataModel = await service.ObtenerItemAsync(request.Termino);

            if (dataModel == null)
            {
                throw new NotFoundProjectException("Item not found");
            }

            return mapper.Map<ItemModel>(dataModel);
        }
    }
}
