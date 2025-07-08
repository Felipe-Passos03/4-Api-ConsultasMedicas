using System.ComponentModel.DataAnnotations;

namespace _4_Api_ConsultasMedicas.Application.DTOs.Admin;

public class CreateAdminRequest
{
    [Required(ErrorMessage = "O Email é obrigatório")]
    [EmailAddress(ErrorMessage = "O email deve ser válido")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "A senha é obrigatória")]
    public string Senha { get; set; }
}