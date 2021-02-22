using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Challenge.Domain.Contexts;
using Challenge.Domain.Entities;
using Challenge.Infrastructure.Services;
using Challenge.Infrastructure.Data.Contracts;

namespace Challenge.Application.Services.DbServices
{
    public interface ICurrencyHistoryDbService
    {
        Task InsertarCurrencyHistoryAsync(CurrencyHistoryEntity entity);
        Task InsertarRangoCurrencyHistoryAsync(IEnumerable<CurrencyHistoryEntity> entities);
    }

    public class CurrencyHistoryDbService : ServiceBase<ChallengeDbContext, CurrencyHistoryEntity>, ICurrencyHistoryDbService
    {
        public CurrencyHistoryDbService(ILogger<ServiceBase<ChallengeDbContext, CurrencyHistoryEntity>> logger,
            IRepositoryCommand<ChallengeDbContext, CurrencyHistoryEntity> repositoryCommand,
            IUnitOfWork<ChallengeDbContext> unitOfWork)
            : base(logger, repositoryCommand, unitOfWork) { }

        public async Task InsertarCurrencyHistoryAsync(CurrencyHistoryEntity entity)
        {
            logger.LogInformation("Insertar consulta de moneda");

            RepositoryCommand.Create(entity);

            await UnitOfWork.SaveChangesAsync();
        }

        public async Task InsertarRangoCurrencyHistoryAsync(IEnumerable<CurrencyHistoryEntity> entities)
        {
            logger.LogInformation("Insertar consultas de moneda");

            RepositoryCommand.CreateRange(entities);
            
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
