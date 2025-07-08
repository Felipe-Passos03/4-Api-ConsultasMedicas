using _4_Api_ConsultasMedicas.Domain.Models.Entity;

namespace _4_Api_ConsultasMedicas.Infra.Repository.Consulta;

public interface IConsultaRepository
{
    public Task CreateConsulta(ConsultaEntity?  consulta);
    public Task<List<ConsultaEntity>> GetAllAgendamentosOffSetLimit(int limit, int offset);
    public Task<int> ContarTotal();
    public Task<List<ConsultaEntity>> GetAgendamentoByPacienteId(Guid pacienteId);
    public Task<List<ConsultaEntity>> GetAgendamentoByMedicoId(Guid medicoId);
    public Task<bool> ConsultaDuplicada(Guid pacienteId, string especialidade, DateOnly dataConsulta);
    public Task<ConsultaEntity?> GetConsultaById (Guid consultaId);
    public Task SaveChangesAsync();
    
}