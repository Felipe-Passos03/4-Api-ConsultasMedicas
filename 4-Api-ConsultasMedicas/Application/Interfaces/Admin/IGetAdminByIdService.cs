using _4_Api_ConsultasMedicas.Domain.Models.Entity;
using FluentResults;

namespace _4_Api_ConsultasMedicas.Application.Interfaces.Admin;

public interface IGetAdminByIdService
{
    public Task<Result<AdminEntity>> GetAdminById(Guid id);
}