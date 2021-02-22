using Challenge.Application.Models;
using Challenge.Domain.Entities;

namespace Challenge.Testing.Mocks
{
    public static class UserMock
    {
        public static UserEntity UserEntityMock()
        {
            return new UserEntity
            {
                Apellido = "Apellido",
                Nombre = "Nombre",
                Email = "email@correo.com",
                Password = "Password"
            };
        }

        public static UserModel UserModelMock()
        {
            return new UserModel
            {
                Apellido = "Apellido",
                Nombre = "Nombre",
                Email = "email@correo.com",
                Password = "Password"
            };
        }
    }
}
