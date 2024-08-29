using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Blogly.Domain.Entities;
using Blogly.Sharedkernel;
using Microsoft.IdentityModel.Tokens;

namespace Blogly.Domain;

public static class JwtSecurityUtil
{
    public static string GenerateToken(ApplicationUser user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("IAmTheCornerstoneAndThisIsMySecurityToken.ShareItIfYouMust"));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        
        List<Claim> claims =
        [
            new Claim(ClaimTypes.Sid, user.Id.ToString()),
            new Claim(ClaimTypes.Country, user.Country),
            new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}")
        ];

        switch (user.Role)
        {
            case Role.Admin:
                claims.Add(new Claim(nameof(Role), nameof(Role.Admin)));
                break;
            case Role.Moderator:
                claims.Add(new Claim(nameof(Role), nameof(Role.Moderator)));
                break;
            case Role.Author:
                claims.Add(new Claim(nameof(Role), nameof(Role.Author)));
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        var token = new JwtSecurityToken
        (
            issuer: "Blogly GmBH",
            audience: "http://blogly.com",
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}