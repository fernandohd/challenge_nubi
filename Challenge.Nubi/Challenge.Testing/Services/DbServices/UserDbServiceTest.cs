using System.Linq;
using NUnit.Framework;
using Challenge.Testing.Bases;
using Challenge.Domain.Contexts;
using Challenge.Domain.Entities;
using Challenge.Testing.Builders;
using Challenge.Application.Services.DbServices;
using Challenge.Testing.Mocks;

namespace Challenge.Testing.Services.DbServices
{
    [TestFixture]
    public class UserDbServiceTest : ServiceBaseTest<ChallengeDbContext, UserEntity>
    {
        private UserDbService userDbService;
        private UserEntity user;

        [SetUp]
        public void SetUp()
        {
            userDbService = ServiceBuilder<ChallengeDbContext, UserEntity>.GetService<UserDbService>();
        }

        [TestCase]
        public void ObtenerUsuariosAsyncTest()
        {
            var result = userDbService.ObtenerUsuariosAsync().Result;

            Assert.IsTrue(result.Any());
        }

        [TestCase(4)]
        public void ObtenerUsuarioAsyncTest(int id)
        {
            var result = userDbService.ObtenerUsuarioAsync(id).Result;

            Assert.IsNotNull(result);
        }

        [TestCase]
        [Order(1)]
        public void InsertarUsuarioAsyncTest()
        {
            user = UserMock.UserEntityMock();

            userDbService.InsertarUsuarioAsync(user).Wait();

            Assert.AreNotEqual(0, user.ID);
        }

        [TestCase("Contraseña")]
        [Order(2)]
        public void UpdateUserAsyncTest(string pass)
        {
            user.Password = pass;

            userDbService.ActualizarUsuarioAsync(user).Wait();

            Assert.Pass();
        }

        [TestCase]
        [Order(3)]
        public void DeleteUserAsyncTest()
        {
            userDbService.EliminarUsuarioAsync(user.ID).Wait();

            Assert.Pass();
        }
    }
}
