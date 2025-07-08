using _4_Api_ConsultasMedicas.Application.Interfaces.Consulta;
using _4_Api_ConsultasMedicas.Domain.Models.Entity;
using _4_Api_ConsultasMedicas.Infra.Repository.Consulta;
using FluentResults;

namespace _4_Api_ConsultasMedicas.Application.Services.Consulta;

public class GetAgendamentoByMedicoService :  IGetAgendamentoByMedicoService
{
    private readonly IConsultaRepository _consultaRepository;

    public GetAgendamentoByMedicoService(IConsultaRepository consultaRepository)
    {
        _consultaRepository = consultaRepository;
    }
    
    public async Task<Result<List<ConsultaEntity>>> GetAgendamentosByMedicoId(Guid medicoId)
    {
        try
        {
            if (medicoId == Guid.Empty)
                return Result.Fail("Id obrigatório");

            var agendamentos = await _consultaRepository.GetAgendamentoByMedicoId(medicoId);

            if (agendamentos == null)
                return Result.Fail("Não há nenhum agendamento");
            
            return Result.Ok(agendamentos);
        }
        catch (Exception e)
        {
            return Result.Fail(e.Message);
        }
    }
}