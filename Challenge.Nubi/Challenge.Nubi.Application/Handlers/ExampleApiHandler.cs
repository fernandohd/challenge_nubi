using AutoMapper;
using Challenge.Nubi.Application.Services.ApiServices;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge.Nubi.Application.Handlers
{
    public class ExampleApiHandlerRequest : IRequest<Models.ExampleModel>
    {
        public Models.Requests.ExampleModel Request { get; }

        public ExampleApiHandlerRequest(Models.Requests.ExampleModel request)
        {
            Request = request;
        }
    }

    public class ExampleApiHandler : IRequestHandler<ExampleApiHandlerRequest, Models.ExampleModel>
    {
        private readonly ILogger<ExampleApiHandler> logger;
        private readonly IExampleApiService exampleApiService;
        private readonly IMapper mapper;

        public ExampleApiHandler(ILogger<ExampleApiHandler> logger, IExampleApiService exampleApiService, IMapper mapper)
        {
            this.logger = logger;
            this.exampleApiService = exampleApiService;
            this.mapper = mapper;
        }

        public async Task<Models.ExampleModel> Handle(ExampleApiHandlerRequest request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Iniciando: {handleName}.Handle(param: {param})", nameof(ExampleApiHandler), request.Request.ExampleProperty);

            var result = await exampleApiService.ExampleMethodAsync(request.Request.ExampleProperty);

            return mapper.Map<Models.ExampleModel>(result);
        }
    }
}
