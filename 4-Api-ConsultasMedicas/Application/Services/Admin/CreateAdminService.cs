using _4_Api_ConsultasMedicas.Application.DTOs.Admin;
using _4_Api_ConsultasMedicas.Application.Interfaces.Admin;
using _4_Api_ConsultasMedicas.Application.Validators;
using _4_Api_ConsultasMedicas.Domain.Models;
using _4_Api_ConsultasMedicas.Domain.Models.Entity;
using _4_Api_ConsultasMedicas.Infra.Repository.Admin;
using FluentResults;

namespace _4_Api_ConsultasMedicas.Application.Services.Admin;

public class CreateAdminService : ICreateAdminService
{
    private readonly IAdminRepository _adminRepository;

    public CreateAdminService(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }
    
    public async Task<Result<CreateAdminResponse>> CreateAdmin(CreateAdminRequest request)
    {
        try
        {
            var EmailAlreadyExists = await _adminRepository.EmailAlreadExists(request.Email);
       
            if (EmailAlreadyExists)
                return Result.Fail<CreateAdminResponse>("Esse email já está sendo utilizado");

            var encriptedPassword = PasswordEncryptor.Encriptor(request.Senha);
            
            var admin = new AdminEntity(request.Email, encriptedPassword);

            await _adminRepository.Create(admin);
            await  _adminRepository.SaveChangesAsync();

            var response = new CreateAdminResponse
            {
                AdminId = admin.AdminId,
                Email = admin.Email,
            };
       
            return Result.Ok(response);
        }
        catch (Exception e)
        {
            return Result.Fail<CreateAdminResponse>($"Erro ao criar a admin {e.Message}");
        }
    }
}