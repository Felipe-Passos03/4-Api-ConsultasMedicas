using FluentResults;

namespace _4_Api_ConsultasMedicas.Application.Interfaces.Admin;

public interface IDeleteAdminById
{
    public Task<Result> DeleteAdminById(Guid id);
}