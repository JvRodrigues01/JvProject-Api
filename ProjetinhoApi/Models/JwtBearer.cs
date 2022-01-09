using System.ComponentModel.DataAnnotations;

namespace ProjetinhoApi.Models
{
    public class JwtBearer
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double DurationInMinutes { get; set; }
    }
}
