
using System.ComponentModel.DataAnnotations;

namespace _4_Api_ConsultasMedicas.Application.DTOs.Paciente;

public class UpdatePacienteRequest
{
    [Required(ErrorMessage = "Id obrigatório")]
    public Guid IdPaciente { get; set; }
    
    [Required(ErrorMessage = "Nome obrigatório")]
    public string Nome { get; set; }
}