using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Challenge.Application.Models;
using Challenge.Application.Services.DbServices;

namespace Challenge.Application.Handlers
{
    public class ObtenerUsuariosRequest : IRequest<IEnumerable<UserModel>> { }

    public class ObtenerUsuariosHandler : IRequestHandler<ObtenerUsuariosRequest, IEnumerable<UserModel>>
    {
        private readonly ILogger<ObtenerUsuariosHandler> logger;
        private readonly IUserDbService service;
        private readonly IMapper mapper;

        public ObtenerUsuariosHandler(ILogger<ObtenerUsuariosHandler> logger, IUserDbService service, IMapper mapper)
        {
            this.logger = logger;
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<UserModel>> Handle(ObtenerUsuariosRequest request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Obtener todos los usuarios");

            var entities = await service.ObtenerUsuariosAsync();

            return mapper.Map<IEnumerable<UserModel>>(entities);
        }
    }
}
