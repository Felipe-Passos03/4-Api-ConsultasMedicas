using _4_Api_ConsultasMedicas.Application.DTOs.Auth;
using FluentResults;
using Microsoft.AspNetCore.Identity.Data;

namespace _4_Api_ConsultasMedicas.Application.Interfaces.Auth;

public interface ILoginAdminService
{
    public Task<Result<LoginResponse>> Login (LoginRequests loginRequest);
}