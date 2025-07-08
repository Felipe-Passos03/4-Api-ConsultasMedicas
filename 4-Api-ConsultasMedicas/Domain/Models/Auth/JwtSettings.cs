namespace _4_Api_ConsultasMedicas.Domain.Models.Auth;

public class JwtSettings
{
    public string SecretKey { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int MedicoExpirationHours { get; set; }
    public int AdminExpirationHours { get; set; }
    public int PacienteExpirationHours { get; set; }
}