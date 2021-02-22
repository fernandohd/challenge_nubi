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
    public class ObtenerUsuariosHandlerTest : HandlerBaseTest<ObtenerUsuariosHandler>
    {
        private IUserDbService service;
        private ObtenerUsuariosRequest request;

        [SetUp]
        public void SetUp()
        {
            service = ServiceBuilder<ChallengeDbContext, UserEntity>.GetService<UserDbService>();

            Handler = new ObtenerUsuariosHandler(Logger, service, Mapper);
        }

        [TestCase]
        public void Handle()
        {
            request = new ObtenerUsuariosRequest();

            var result = Handler.Handle(request, CancellationToken).Result;

            Assert.IsTrue(result.Any());
        }
    }
}
