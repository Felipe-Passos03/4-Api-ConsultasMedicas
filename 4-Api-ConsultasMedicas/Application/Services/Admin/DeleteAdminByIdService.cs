using _4_Api_ConsultasMedicas.Application.Interfaces.Admin;
using _4_Api_ConsultasMedicas.Infra.Repository.Admin;
using FluentResults;

namespace _4_Api_ConsultasMedicas.Application.Services.Admin;

public class DeleteAdminByIdService :  IDeleteAdminById
{
    private readonly IAdminRepository _adminRepository;
    private readonly IGetAdminByIdService _getAdminByIdService;

    public DeleteAdminByIdService(IAdminRepository adminRepository, IGetAdminByIdService getAdminByIdService)
    {
        _adminRepository = adminRepository;
        _getAdminByIdService = getAdminByIdService;
    }
    
    public async Task<Result> DeleteAdminById(Guid id)
    {
        try
        {
            var adminExists = _adminRepository.GetAdminById(id);

            if (adminExists == null)
                return Result.Fail("Esse admin não existe");

            await _adminRepository.RemoveAdminById(id);
            await _adminRepository.SaveChangesAsync();
            
            return Result.Ok();
        }
        catch (Exception e)
        {
            return Result.Fail(e.Message);
        }
    }
}