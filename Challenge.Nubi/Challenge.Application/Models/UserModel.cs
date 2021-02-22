using Newtonsoft.Json;

namespace Challenge.Application.Models
{
    public class UserModel
    {
        [JsonIgnore]
        public int ID { get; set; }

        [JsonProperty("apellido")]
        public string Apellido { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
