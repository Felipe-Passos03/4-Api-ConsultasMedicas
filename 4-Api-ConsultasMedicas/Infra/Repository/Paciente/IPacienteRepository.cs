using _4_Api_ConsultasMedicas.Domain.Models.Entity;

namespace _4_Api_ConsultasMedicas.Infra.Repository.Paciente;

public interface IPacienteRepository
{
    public Task Create(PacienteEntity paciente);
    public Task<PacienteEntity> GetById(Guid id);
    public Task<List<PacienteEntity>> GetAll();
    public Task SaveChangesAsync();
    public Task<PacienteEntity> GetByCpf(string cpf);
    public Task<bool> IsInadimplente(Guid id);
}