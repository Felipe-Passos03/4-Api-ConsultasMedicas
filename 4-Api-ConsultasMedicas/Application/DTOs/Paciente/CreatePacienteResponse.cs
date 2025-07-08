namespace _4_Api_ConsultasMedicas.Application.DTOs.Paciente;

public class CreatePacienteResponse
{
    public Guid id { get; set; }
    public string Nome { get; set;}
    public string CPF { get; set;}
    public bool EstaInadimplente { get; set; }
}