using _4_Api_ConsultasMedicas.Application.DTOs.Medico;
using _4_Api_ConsultasMedicas.Application.Interfaces.Medico;
using _4_Api_ConsultasMedicas.Domain.Models.Entity;
using _4_Api_ConsultasMedicas.Infra.Repository.Medico;
using FluentResults;

namespace _4_Api_ConsultasMedicas.Application.Services.Medico;

public class CreateMedicoService : ICreateMedicoService
{
    private readonly IMedicoRepository  _medicoRepository;
    private readonly IValidarCrmService  _validarCrmService;

    public CreateMedicoService(IMedicoRepository medicoRepository, 
                                IValidarCrmService validarCrmService)
    {
        _medicoRepository = medicoRepository;
        _validarCrmService = validarCrmService;
    }
    
    public async Task<Result<CreateMedicoResponse>> CreateAsync(CreateMedicoRequest medicoRequest)
    {
        try
        {
            var crmValido = _validarCrmService.ValidarCrm(medicoRequest.CRM);
        
            if (!crmValido)
                return Result.Fail<CreateMedicoResponse>("Crm invalido");
        
            var crmExiste = await _medicoRepository.FindCrm(medicoRequest.CRM);
        
            if (crmExiste != null)
                return  Result.Fail<CreateMedicoResponse>("Esse crm já está registrado");
        
            var medico = new MedicoEntity(medicoRequest.Nome, medicoRequest.Especialidade, medicoRequest.CRM);

            await _medicoRepository.Create(medico);
            await _medicoRepository.SaveChangesAsync();
            
            var response  = new CreateMedicoResponse
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
            return Result.Fail<CreateMedicoResponse>(e.Message);
        }
        

        //ValidarFormatoCRM
        //Get CRM (Se já existir um CRM registrado no banco, não deixar criar)
        //CriarMedico
        //
    }
}