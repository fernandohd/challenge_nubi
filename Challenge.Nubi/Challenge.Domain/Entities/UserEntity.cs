using Challenge.Infrastructure.Data;

namespace Challenge.Domain.Entities
{
    public class UserEntity : EntityBase
    {
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
