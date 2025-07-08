using _4_Api_ConsultasMedicas.Application.Interfaces.Medico;
using _4_Api_ConsultasMedicas.Domain.Models.Entity;
using _4_Api_ConsultasMedicas.Infra.Repository.Medico;
using FluentResults;

namespace _4_Api_ConsultasMedicas.Application.Services.Medico;

public class GetMedicoByIdService : IGetMedicoByIdService
{
    private readonly IMedicoRepository _medicoRepository;

    public GetMedicoByIdService(IMedicoRepository medicoRepository)
    {
        _medicoRepository = medicoRepository;
    }
    
    public async Task<Result<MedicoEntity>> GetMedicoById(Guid id)
    {
        try
        {
            if (id == Guid.Empty)
                return Result.Fail("Campo id obrigatório");

            var getId = await _medicoRepository.GetById(id);

            if (getId == null)
                return Result.Fail("Esse médico não está registrado");

            return getId;

        }
        catch (Exception e)
        {
            return Result.Fail(e.Message);
        }
      
    }
}