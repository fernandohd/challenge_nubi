using NUnit.Framework;
using Challenge.Domain.Contexts;
using Challenge.Domain.Entities;
using Challenge.Testing.Bases;
using Challenge.Testing.Builders;
using Challenge.Application.Models;
using Challenge.Application.Handlers;
using Challenge.Application.Services.DbServices;

namespace Challenge.Testing.Handlers
{
    [TestFixture]
    public class ActualizarUsuarioHandlerTest : HandlerBaseTest<ActualizarUsuarioHandler>
    {
        private IUserDbService service;
        private ActualizarUsuarioRequest request;
        private UserModel user;

        [SetUp]
        public void SetUp()
        {
            service = ServiceBuilder<ChallengeDbContext, UserEntity>.GetService<UserDbService>();
            Handler = new ActualizarUsuarioHandler(Logger, service, Mapper);
        }

        [TestCase]
        public void Handle()
        {
            var entity = service.ObtenerUsuarioAsync(1).Result;

            entity.Password += "Test";

            user = Mapper.Map<UserModel>(entity);

            request = new ActualizarUsuarioRequest(user);

            Handler.Handle(request, CancellationToken).Wait();

            Assert.Pass();
        }
    }
}
