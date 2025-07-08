namespace _4_Api_ConsultasMedicas.Application.DTOs.Medico;

public class CreateMedicoResponse
{
    
    
    public Guid id { get; set; }
    
    public string Nome { get; set; }
    
    public string Especialidade { get;  set; }
    
    public string CRM { get; set; }
    
    public bool Ativo { get; set; }
}