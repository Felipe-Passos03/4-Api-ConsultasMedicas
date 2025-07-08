using _4_Api_ConsultasMedicas.Domain.Models.Entity;

namespace _4_Api_ConsultasMedicas.Infra.Repository.Medico;

public interface IMedicoRepository
{
    public Task Create(MedicoEntity medico);
    public Task<MedicoEntity> GetById(Guid id);
    public Task<List<MedicoEntity>> GetAll();
    public Task SaveChangesAsync();
    public Task<MedicoEntity> FindCrm(string crm);
    public Task<MedicoEntity?> GetMedicoAvaliable(string especialidade,  DateOnly dataConsulta, TimeOnly horaConsulta);

    public Task<List<MedicoEntity>> BuscarByEspecialidade(string especialidade);
}