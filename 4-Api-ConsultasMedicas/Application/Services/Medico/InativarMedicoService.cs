using _4_Api_ConsultasMedicas.Application.Interfaces.Medico;
using _4_Api_ConsultasMedicas.Infra.Repository.Medico;
using FluentResults;

namespace _4_Api_ConsultasMedicas.Application.Services.Medico;

public class InativarMedicoService :  IInativarMedicoService
{
    private readonly IMedicoRepository _medicoRepository;

    public InativarMedicoService(IMedicoRepository medicoRepository)
    {
        _medicoRepository = medicoRepository;
    }
    
    public async Task<Result> Inativar(Guid id)
    {
        try
        {
            if(id == Guid.Empty)
                return Result.Fail("Id obrigatório");
        
            var medico = await _medicoRepository.GetById(id);

            if (medico == null)
                return Result.Fail("Esse médico não existe");
        
            medico.AtualizarStatus();

            await _medicoRepository.SaveChangesAsync();
        
            return Result.Ok();
        }
        catch (Exception e)
        {
            return Result.Fail(e.Message);
        }
    }
}