using _4_Api_ConsultasMedicas.Application.DTOs.Admin;
using _4_Api_ConsultasMedicas.Domain.Models;
using FluentResults;

namespace _4_Api_ConsultasMedicas.Application.Interfaces.Admin;

public interface ICreateAdminService
{
    public Task<Result<CreateAdminResponse>> CreateAdmin(CreateAdminRequest admin);
}