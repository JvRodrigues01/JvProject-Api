using Microsoft.IdentityModel.Tokens;
using ProjetinhoApi.Models;
using System.IdentityModel.Tokens.Jwt;

namespace ProjetinhoApi.Services.Interfaces
{
    public interface ITokenService
    {
        JwtSecurityToken CreateJwtToken(User user);
    }
}
