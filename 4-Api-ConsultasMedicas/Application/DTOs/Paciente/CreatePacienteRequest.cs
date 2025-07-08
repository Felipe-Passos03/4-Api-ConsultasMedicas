using System.ComponentModel.DataAnnotations;

namespace _4_Api_ConsultasMedicas.Application.DTOs.Paciente;

public class CreatePacienteRequest
{
    [Required(ErrorMessage = "Nome obrigatório")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "CPF obrigatório")]
    public string CPF { get; set; }
}