using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Challenge.Domain.Entities;
using Challenge.Application.Models;
using Challenge.Infrastructure.Exceptions;
using Challenge.Application.Services.DbServices;

namespace Challenge.Application.Handlers
{
    public class ActualizarUsuarioRequest : IRequest
    {
        public ActualizarUsuarioRequest(UserModel user)
        {
            User = user;
        }

        public UserModel User { get; }
    }

    public class ActualizarUsuarioHandler : IRequestHandler<ActualizarUsuarioRequest>
    {
        private readonly ILogger<ActualizarUsuarioHandler> logger;
        private readonly IUserDbService service;
        private readonly IMapper mapper;

        public ActualizarUsuarioHandler(ILogger<ActualizarUsuarioHandler> logger, IUserDbService service, IMapper mapper)
        {
            this.logger = logger;
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(ActualizarUsuarioRequest request, CancellationToken cancellationToken)
        {
            if (request.User == null)
            {
                throw new BadRequestProjectException("Invalid user");
            }

            logger.LogInformation("Actualizar usuario", $"{request.User.Apellido} {request.User.Nombre}");

            var entity = mapper.Map<UserEntity>(request.User);

            await service.ActualizarUsuarioAsync(entity);

            return Unit.Value;
        }
    }
}
