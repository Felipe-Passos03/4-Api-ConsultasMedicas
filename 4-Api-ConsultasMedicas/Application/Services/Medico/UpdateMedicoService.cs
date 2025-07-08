using _4_Api_ConsultasMedicas.Application.DTOs.Medico;
using _4_Api_ConsultasMedicas.Application.Interfaces.Medico;
using _4_Api_ConsultasMedicas.Infra.Repository.Medico;
using FluentResults;

namespace _4_Api_ConsultasMedicas.Application.Services.Medico;

public class UpdateMedicoService : IUpdateMedicoService
{
    private readonly IMedicoRepository _medicoRepository;

    public UpdateMedicoService(IMedicoRepository medicoRepository)
    {
        _medicoRepository = medicoRepository;
    }
    
    public async Task<Result<UpdateMedicoResponse>> UpdateMedico(UpdateMedicoRequest request)
    {
        try
        {
            if (request.idMedico == Guid.Empty)
                return Result.Fail("Obrigatório id");
            
            var medico = await _medicoRepository.GetById(request.idMedico);

            if (medico == null)
                return Result.Fail("Esse médico não está registrado");
        
            medico.AtualizarMedico(request.Nome, request.Especialidade);
            await _medicoRepository.SaveChangesAsync();
            
            var response = new UpdateMedicoResponse
            {
                id = medico.MedicoId,
                Nome = medico.Nome,
                Especialidade = medico.Especialidade,
                CRM = medico.CRM,
                Ativo = medico.Ativo
                
            };
            
            return Result.Ok(response);
        }
        catch (Exception e)
        {
            return Result.Fail(e.Message);
        }
    }
}