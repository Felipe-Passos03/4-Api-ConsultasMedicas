using _4_Api_ConsultasMedicas.Application.Interfaces.Paciente;
using _4_Api_ConsultasMedicas.Domain.Models.Entity;
using _4_Api_ConsultasMedicas.Infra.Repository.Paciente;
using FluentResults;

namespace _4_Api_ConsultasMedicas.Application.Services.Paciente;

public class GetPacienteByIdService :  IGetPacienteByIdService
{
    private readonly IPacienteRepository _repository;

    public GetPacienteByIdService(IPacienteRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Result<PacienteEntity>> GetById(Guid id)
    {
        try
        {
            if(id == Guid.Empty)
                return Result.Fail("Campo id obrigatorio");
            
            var getPaciente = await _repository.GetById(id);

            if (getPaciente == null)
                return Result.Fail("Esse paciente não existe");
            
            return Result.Ok(getPaciente);
        }
        catch (Exception e)
        {
           return Result.Fail(e.Message);
        }
    }
}