using System.Text.Json.Serialization;

namespace _4_Api_ConsultasMedicas.Application.DTOs.Admin;

public class CreateAdminResponse
{
    [JsonPropertyName("id")]
    public Guid AdminId { get; set; }
    
    [JsonPropertyName("email")]
    public string Email { get; set; }
}