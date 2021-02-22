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
    public class InsertarUsuarioRequest : IRequest
    {
        public InsertarUsuarioRequest(UserModel user)
        {
            User = user;
        }

        public UserModel User { get; }
    }

    public class InsertarUsuarioHandler : IRequestHandler<InsertarUsuarioRequest>
    {
        private readonly ILogger<InsertarUsuarioHandler> logger;
        private readonly IUserDbService service;
        private readonly IMapper mapper;

        public InsertarUsuarioHandler(ILogger<InsertarUsuarioHandler> logger, IUserDbService service, IMapper mapper)
        {
            this.logger = logger;
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(InsertarUsuarioRequest request, CancellationToken cancellationToken)
        {
            if (request.User == null)
            {
                throw new BadRequestProjectException("Invalid user");
            }

            logger.LogInformation("Insertar usuario", $"{request.User.Apellido} {request.User.Nombre}");

            var entity = mapper.Map<UserEntity>(request.User);

            await service.InsertarUsuarioAsync(entity);

            if (entity.ID == 0)
            {
                throw new ConflictProjectException("Unable to insert");
            }

            return Unit.Value;
        }
    }
}
