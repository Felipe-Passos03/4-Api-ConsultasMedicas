using System.ComponentModel.DataAnnotations;

namespace _4_Api_ConsultasMedicas.Application.DTOs.Medico;

public class CreateMedicoRequest
{
    [Required(ErrorMessage = "Nome obrigatório")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "Especialidade obrigatória")]
    public string Especialidade { get;  set; }
    
    [Required(ErrorMessage = "CRM obrigatório")]
    public string CRM { get; set; }
}