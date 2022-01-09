using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProjetinhoApi.Models;
using ProjetinhoApi.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjetinhoApi.Services
{
    public class TokenService : ITokenService
    {
        private readonly IOptions<JwtBearer> jwtBearer;

        public TokenService(IOptions<JwtBearer> jwtBearer)
        {
            this.jwtBearer = jwtBearer;
        }

        public JwtSecurityToken CreateJwtToken(User user)
        {
            var authClaims = new List<Claim>
            {
                new Claim("user", user.Username),
            };

            // Define the key signing token to be used
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtBearer.Value.Key));

            // Create the Jwt Token to be returned
            return new JwtSecurityToken(
                issuer: jwtBearer.Value.Issuer,
                audience: jwtBearer.Value.Audience,
                expires: DateTime.Now.Add(TimeSpan.FromMinutes(jwtBearer.Value.DurationInMinutes)),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );
        }
    }
}
