using _4_Api_ConsultasMedicas.Domain.Models.Enum.ConsultaEnum;

namespace _4_Api_ConsultasMedicas.Application.DTOs.Consulta;

public class CreateAgendamentoResponse
{
    public Guid MedicoId { get; set; }
    public Guid PacienteId { get; set; }
    public DateOnly DataConsulta { get; set; }
    public TimeOnly HorarioConsulta { get; set; }
    public StatusConsulta Status {get; set;}
    public string Especialidade { get; set; }
}