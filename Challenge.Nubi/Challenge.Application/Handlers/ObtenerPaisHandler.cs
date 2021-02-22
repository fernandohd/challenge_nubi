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
    public class ObtenerPaisRequest : IRequest<PaisModel>
    {
        public ObtenerPaisRequest(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }

    public class ObtenerPaisHandler : IRequestHandler<ObtenerPaisRequest, PaisModel>
    {
        public ObtenerPaisHandler(ILogger<ObtenerPaisHandler> logger, IPaisesApiService service, IMapper mapper)
        {
            this.logger = logger;
            this.service = service;
            this.mapper = mapper;
        }

        private readonly ILogger<ObtenerPaisHandler> logger;
        private readonly IPaisesApiService service;
        private readonly IMapper mapper;

        public async Task<PaisModel> Handle(ObtenerPaisRequest request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Obteniendo pais por id {id}", request.Id);

            if (string.IsNullOrWhiteSpace(request.Id))
            {
                throw new BadRequestProjectException("Invalid country id");
            }

            var dataModel = await service.ObtenerPaisAsync(request.Id);

            if (dataModel == null)
            {
                throw new NotFoundProjectException("Country id not found");
            }

            return mapper.Map<PaisModel>(dataModel);
        }
    }
}
