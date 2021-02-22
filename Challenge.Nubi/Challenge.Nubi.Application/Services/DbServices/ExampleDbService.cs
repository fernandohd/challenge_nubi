using Challenge.Nubi.Application.Contexts;
using Challenge.Nubi.Application.Entities;
using Microsoft.Extensions.Logging;
using Challenge.Nubi.Infrastructure.Data.Contracts;
using Challenge.Nubi.Infrastructure.Services;
using System.Threading.Tasks;

namespace Challenge.Nubi.Application.Services.DbServices
{
    public interface IExampleDbService
    {
        Task<ExampleEntity> ExampleMethodAsync(int id);
    }

    public class ExampleDbService : ServiceBase<ExampleDbContext, ExampleEntity>, IExampleDbService
    {
        private readonly ILogger<ExampleDbService> logger;

        public ExampleDbService(ILogger<ExampleDbService> logger, IRepositoryQuery<ExampleDbContext, ExampleEntity> repositoryQuery, IUnitOfWork<ExampleDbContext> unitOfWork)
            : base(logger, repositoryQuery, unitOfWork)
        {
            this.logger = logger;
        }

        public async Task<ExampleEntity> ExampleMethodAsync(int id)
        {
            logger.LogInformation("Iniciando: {methodName}(id: {id})", nameof(ExampleMethodAsync), id);

            var result = await GetAsync(id);

            return result;
        }
    }
}
