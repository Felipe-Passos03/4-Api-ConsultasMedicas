
using _4_Api_ConsultasMedicas.Application.Interfaces.Paciente;
using _4_Api_ConsultasMedicas.Infra.Repository.Paciente;
using FluentResults;

namespace _4_Api_ConsultasMedicas.Application.Services.Paciente;

public class AlterarStatusPacienteService :  IAlterarStatusPacienteService
{
    private readonly IPacienteRepository  _pacienteRepository;

    public AlterarStatusPacienteService(IPacienteRepository pacienteRepository)
    {
        _pacienteRepository = pacienteRepository;
    }


    public async Task<Result> AlterarStatusPaciente(Guid id)
    {
        try
        {
            if(id == Guid.Empty)
                return Result.Fail("Informe o id do paciente");

            var paciente = await _pacienteRepository.GetById(id);
            
            if(paciente == null)
                return Result.Fail("Esse paciente não existe");
        
            if(paciente.EstaInadimplente)
                return Result.Fail("Esse paciente já está inadimplente");
            
            paciente.AlterarStatus();
            await _pacienteRepository.SaveChangesAsync();
        
            return Result.Ok();
        }
        catch (Exception e)
        {
            return Result.Fail(e.Message);
        }
    }
}