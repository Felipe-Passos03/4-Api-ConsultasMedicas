using System.ComponentModel.DataAnnotations;

namespace _4_Api_ConsultasMedicas.Application.DTOs.Medico;

public class UpdateMedicoRequest
{
    [Required(ErrorMessage = "Id obrigatório")]
    public Guid idMedico { get; set; }
    
    [Required(ErrorMessage = "Nome obrigatório")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "Especialidade obrigatória")]
    public string Especialidade { get;  set; }
}