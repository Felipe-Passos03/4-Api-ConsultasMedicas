using _4_Api_ConsultasMedicas.Application.Interfaces.Consulta;
using _4_Api_ConsultasMedicas.Domain.Models.Entity;
using _4_Api_ConsultasMedicas.Infra.Repository.Consulta;
using FluentResults;

namespace _4_Api_ConsultasMedicas.Application.Services.Consulta;

public class GetAgendamentoByPacienteService : IGetAgendamentoByPacienteService
{
    private readonly IConsultaRepository  _consultaRepository;

    public GetAgendamentoByPacienteService(IConsultaRepository consultaRepository)
    {
        _consultaRepository = consultaRepository;
    }
    
    public async Task<Result<List<ConsultaEntity>>> GetConsultasByPaciente(Guid pacienteId)
    {
        try
        {
            if (pacienteId == Guid.Empty)
                return Result.Fail("Esse paciente não existe");
        
            var consultas = await _consultaRepository.GetAgendamentoByPacienteId(pacienteId);

            if (consultas == null)
                return Result.Fail("Esse paciente não possui consultas agendadas");
            
            return Result.Ok(consultas);
        }
        catch (Exception e)
        {
            return Result.Fail(e.Message);
        }
       
        
        
    }
}