using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Challenge.Infrastructure.Exceptions;
using Challenge.Application.Services.DbServices;

namespace Challenge.Application.Handlers
{
    public class EliminarUsuarioRequest : IRequest
    {
        public EliminarUsuarioRequest(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }

    public class EliminarUsuarioHandler : IRequestHandler<EliminarUsuarioRequest>
    {
        private readonly ILogger<EliminarUsuarioHandler> logger;
        private readonly IUserDbService service;
        private readonly IMapper mapper;

        public EliminarUsuarioHandler(ILogger<EliminarUsuarioHandler> logger, IUserDbService service, IMapper mapper)
        {
            this.logger = logger;
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(EliminarUsuarioRequest request, CancellationToken cancellationToken)
        {
            if (request.Id == 0)
            {
                throw new BadRequestProjectException("Invalid user ID");
            }

            logger.LogInformation("Eliminar usuario", request.Id);

            await service.EliminarUsuarioAsync(request.Id);

            return Unit.Value;
        }
    }
}
