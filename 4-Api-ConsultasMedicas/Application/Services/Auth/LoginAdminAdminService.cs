using _4_Api_ConsultasMedicas.Application.DTOs.Auth;
using _4_Api_ConsultasMedicas.Application.Interfaces.Auth;
using _4_Api_ConsultasMedicas.Domain.Models.Services.Jwt;
using _4_Api_ConsultasMedicas.Infra.Data;
using FluentResults;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace _4_Api_ConsultasMedicas.Application.Services.Auth;

public class LoginAdminAdminService :  ILoginAdminService
{
    private readonly AppDbContext _context;

    public LoginAdminAdminService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Result<LoginResponse>> Login(LoginRequests loginRequest)
    {
        try
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(admin => admin.Email == loginRequest.Email);

            if (admin != null && BCrypt.Net.BCrypt.Verify(loginRequest.Senha, admin.Senha))
            {
                var token = JwtTokenService.GenerateAdminToken(admin.Email);
                var response = new LoginResponse
                {
                    Token = token,
                };
                return Result.Ok(response);
            }
        
            return Result.Fail<LoginResponse>("Credenciais inválidas");
        }
        catch (Exception e)
        {
           return  Result.Fail<LoginResponse>(e.Message);
        }
    }
}