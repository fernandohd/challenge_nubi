using System.Linq;
using NUnit.Framework;
using Challenge.Domain.Contexts;
using Challenge.Domain.Entities;
using Challenge.Testing.Bases;
using Challenge.Testing.Builders;
using Challenge.Application.Handlers;
using Challenge.Application.Services.DbServices;

namespace Challenge.Testing.Handlers
{
    [TestFixture]
    public class EliminarUsuarioHandlerTest : HandlerBaseTest<EliminarUsuarioHandler>
    {
        private IUserDbService service;
        private EliminarUsuarioRequest request;

        [SetUp]
        public void SetUp()
        {
            service = ServiceBuilder<ChallengeDbContext, UserEntity>.GetService<UserDbService>();
            Handler = new EliminarUsuarioHandler(Logger, service, Mapper);
        }

        [TestCase]
        public void Handle()
        {
            var users = service.ObtenerUsuariosAsync().Result;

            int? id = users.LastOrDefault()?.ID;

            request = new EliminarUsuarioRequest(id ?? 0);

            Handler.Handle(request, CancellationToken).Wait();

            Assert.Pass();
        }
    }
}
