using _4_Api_ConsultasMedicas.Application.Interfaces.Consulta;
using _4_Api_ConsultasMedicas.Domain.Models.Enum.ConsultaEnum;
using _4_Api_ConsultasMedicas.Infra.Repository.Consulta;
using FluentResults;

namespace _4_Api_ConsultasMedicas.Application.Services.Consulta;

public class FinalizarAgendamentoService :  IFinalizarAgendamentoService
{
    private readonly IConsultaRepository _consultaRepository;

    public FinalizarAgendamentoService(IConsultaRepository consultaRepository)
    {
        _consultaRepository = consultaRepository;
    }
    
    public async Task<Result> FinalizarAgendamentoAsync(Guid id)
    {
        try
        {
            var agendamento = await _consultaRepository.GetConsultaById(id);
        
            if (agendamento == null)
                return Result.Fail("Esse agendamento não existe");

            if (agendamento.Status == StatusConsulta.Finalizada)
                return Result.Fail("Essa consulta já foi finalizada");

            if (agendamento.Status == StatusConsulta.Cancelada)
                return Result.Fail("Essa consulta já foi cancelada");
            
            var dataHoraConsulta = agendamento.DataConsulta.ToDateTime(agendamento.HorarioConsulta);

            if (DateTime.Now <= dataHoraConsulta)
                return Result.Fail
                    ($"Você só pode finalizar a consulta após ela ter sido realizada, " +
                     $"só é possível finalizar após o dia {agendamento.DataConsulta}");
            
            agendamento.FinalizarConsulta();
            
            await _consultaRepository.SaveChangesAsync();
            
            return Result.Ok();
        }
        catch (Exception e)
        {
            return Result.Fail(e.Message);
        }
    }
}