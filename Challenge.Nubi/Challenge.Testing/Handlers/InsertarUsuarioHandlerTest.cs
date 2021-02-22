using NUnit.Framework;
using Challenge.Testing.Mocks;
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
    public class InsertarUsuarioHandlerTest : HandlerBaseTest<InsertarUsuarioHandler>
    {
        private IUserDbService service;
        private InsertarUsuarioRequest request;
        private UserModel user;

        [SetUp]
        public void SetUp()
        {
            service = ServiceBuilder<ChallengeDbContext, UserEntity>.GetService<UserDbService>();
            Handler = new InsertarUsuarioHandler(Logger, service, Mapper);
            user = UserMock.UserModelMock();
        }

        [TestCase]
        public void Handle()
        {
            request = new InsertarUsuarioRequest(user);

            Handler.Handle(request, CancellationToken).Wait();

            Assert.Pass();
        }
    }
}
