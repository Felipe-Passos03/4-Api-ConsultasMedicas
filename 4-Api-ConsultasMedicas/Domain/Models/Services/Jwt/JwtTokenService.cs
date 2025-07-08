using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using _4_Api_ConsultasMedicas.Domain.Models.Auth;
using Microsoft.IdentityModel.Tokens;

namespace _4_Api_ConsultasMedicas.Domain.Models.Services.Jwt;

public static class JwtTokenService
{
    private static JwtSettings _jwtSettings;
    
    public static void Initialize(IConfiguration configuration)
    {
        _jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();
    }
    
    public static string GenerateAdminToken(string email)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Email, email),
            new Claim(ClaimTypes.Role, "Admin")
        };

        return GenerateToken(claims, _jwtSettings.AdminExpirationHours); 
    }
    
    private static string GenerateToken(List<Claim> claims, int expirationHours)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = _jwtSettings.Issuer,
            Audience = _jwtSettings.Audience,
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(expirationHours),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };
        return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
    }
    
}