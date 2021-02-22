using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Challenge.Application.Models;
using Challenge.Application.Services.DbServices;

namespace Challenge.Application.Handlers
{
    public class ObtenerUsuarioRequest : IRequest<UserModel> 
    {
        public ObtenerUsuarioRequest(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }

    public class ObtenerUsuarioHandler : IRequestHandler<ObtenerUsuarioRequest, UserModel>
    {
        private readonly ILogger<ObtenerUsuarioHandler> logger;
        private readonly IUserDbService service;
        private readonly IMapper mapper;

        public ObtenerUsuarioHandler(ILogger<ObtenerUsuarioHandler> logger, IUserDbService service, IMapper mapper)
        {
            this.logger = logger;
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<UserModel> Handle(ObtenerUsuarioRequest request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Obtener usuario por ID: {id}", request.Id);

            var entity = await service.ObtenerUsuarioAsync(request.Id);

            return mapper.Map<UserModel>(entity);
        }
    }
}
