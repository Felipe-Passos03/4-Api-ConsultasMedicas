using System.ComponentModel.DataAnnotations;

namespace _4_Api_ConsultasMedicas.Application.DTOs.Consulta;

public class OffSetLimitRequest
{
    [Required]
    public int Limit { get; set; }
    
    [Required]
    public int Offset { get; set; }
}