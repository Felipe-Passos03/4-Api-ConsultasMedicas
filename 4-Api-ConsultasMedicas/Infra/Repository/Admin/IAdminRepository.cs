using _4_Api_ConsultasMedicas.Domain.Models;
using _4_Api_ConsultasMedicas.Domain.Models.Entity;

namespace _4_Api_ConsultasMedicas.Infra.Repository.Admin;

public interface IAdminRepository
{
    public Task Create(AdminEntity admin);
    public Task SaveChangesAsync();

    public Task<bool> EmailAlreadExists(string email);
    public Task<AdminEntity> GetAdminById(Guid id);
    public Task RemoveAdminById(Guid id);
}