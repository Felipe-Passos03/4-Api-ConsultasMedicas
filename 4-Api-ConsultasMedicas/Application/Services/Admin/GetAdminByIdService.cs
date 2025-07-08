using _4_Api_ConsultasMedicas.Application.Interfaces.Admin;
using _4_Api_ConsultasMedicas.Domain.Models.Entity;
using _4_Api_ConsultasMedicas.Infra.Repository.Admin;
using FluentResults;

namespace _4_Api_ConsultasMedicas.Application.Services.Admin;

public class GetAdminByIdService :  IGetAdminByIdService
{
    private readonly IAdminRepository _adminRepository;

    public GetAdminByIdService(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public async Task<Result<AdminEntity>> GetAdminById(Guid id)
    {
        try
        {
            var getAdmin = await _adminRepository.GetAdminById(id);

            if (getAdmin == null)
                return Result.Fail("Esse admin não existe");
        
            return Result.Ok(getAdmin);
        }
        catch (Exception e)
        {
            return Result.Fail(e.Message);
        }
    }
}