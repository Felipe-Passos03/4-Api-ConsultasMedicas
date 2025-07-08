using System.Text.Json.Serialization;
using _4_Api_ConsultasMedicas.Domain.Models.Enum.ConsultaEnum;

namespace _4_Api_ConsultasMedicas.Domain.Models.Entity;

public class ConsultaEntity
{
    public Guid ConsultaId { get; init; }
    public Guid MedicoId { get; set; }
    public Guid PacienteId { get; set; }
    public DateOnly DataConsulta { get; private set; }
    public TimeOnly HorarioConsulta { get; private set; }
    public StatusConsulta Status {get; private set;}
    public string? MotivoCancelamento { get; private set; }
    public string Especialidade { get; private set; }
    
    public MedicoEntity Medico { get; set; }
    
    public PacienteEntity Paciente { get; set; }

    private ConsultaEntity()
    {
        
    }

    public ConsultaEntity(Guid pacienteId,Guid medicoId,DateOnly dataConsulta, TimeOnly horarioConsulta, string especialidade)
    {
        ConsultaId = Guid.NewGuid();
        MedicoId = medicoId;
        PacienteId = pacienteId;
        DataConsulta = dataConsulta;
        HorarioConsulta = horarioConsulta;
        Status = StatusConsulta.Agendada;
        MotivoCancelamento = " ";
        Especialidade = especialidade;

    }

    public void CancelarConsulta(string motivoCancelamento)
    {
        Status = StatusConsulta.Cancelada;
        MotivoCancelamento = motivoCancelamento;
    }

    public void FinalizarConsulta()
    {
        Status = StatusConsulta.Finalizada;
    }
}