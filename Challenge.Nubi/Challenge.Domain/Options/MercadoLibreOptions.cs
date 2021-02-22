using Challenge.Infrastructure.Models;

namespace Challenge.Domain.Options
{
    public class MercadoLibreOptions : HttpOptionsBase
    {
        public string UrlBaseAuth { get; set; }
        public string PublicKeyTesting { get; set; }
        public string AccessTokenTesting { get; set; }

        public string ClienteId { get; set; }
        public string ClienteSecret { get; set; }

        public string ClienteIdTesting { get; set; }
        public string ClienteSecretTesting { get; set; }

        public string UrlPaises { get; set; }
        public string UrlPais { get; set; }
        public string UrlBusqueda { get; set; }
        public string UrlMonedas { get; set; }
        public string UrlMoneda { get; set; }
        public string UrlConversion { get; set; }

        public string[] PaisesEspeciales { get; set; }
        public string[] PaisesInhabilitados { get; set; }

        public MercadoLibreOptions() : base() { }
    }
}
