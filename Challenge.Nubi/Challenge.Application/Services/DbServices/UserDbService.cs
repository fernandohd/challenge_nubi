using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Challenge.Domain.Contexts;
using Challenge.Domain.Entities;
using Challenge.Infrastructure.Services;
using Challenge.Infrastructure.Data.Contracts;

namespace Challenge.Application.Services.DbServices
{
    public interface IUserDbService
    {
        Task<IEnumerable<UserEntity>> ObtenerUsuariosAsync();
        Task<UserEntity> ObtenerUsuarioAsync(int id);
        Task InsertarUsuarioAsync(UserEntity user);
        Task ActualizarUsuarioAsync(UserEntity user);
        Task EliminarUsuarioAsync(int id);
    }

    public class UserDbService : ServiceBase<ChallengeDbContext, UserEntity>, IUserDbService
    {
        public UserDbService(
            ILogger<ServiceBase<ChallengeDbContext, UserEntity>> logger,
            IRepositoryCommand<ChallengeDbContext, UserEntity> repositoryCommand,
            IUnitOfWork<ChallengeDbContext> unitOfWork)
            : base(logger, repositoryCommand, unitOfWork) { }

        public async Task<IEnumerable<UserEntity>> ObtenerUsuariosAsync()
        {
            var users = await RepositoryCommand.GetAllAsync();

            return users;
        }

        public async Task<UserEntity> ObtenerUsuarioAsync(int id)
        {
            var user = await RepositoryCommand.GetAsync(x => x.ID == id);

            return user.FirstOrDefault();
        }

        public async Task InsertarUsuarioAsync(UserEntity user)
        {
            RepositoryCommand.Create(user);

            await UnitOfWork.SaveChangesAsync();
        }

        public async Task ActualizarUsuarioAsync(UserEntity user)
        {
            RepositoryCommand.Update(user);

            await UnitOfWork.SaveChangesAsync();
        }

        public async Task EliminarUsuarioAsync(int id)
        {
            RepositoryCommand.Delete(id);

            await UnitOfWork.SaveChangesAsync();
        }
    }
}
