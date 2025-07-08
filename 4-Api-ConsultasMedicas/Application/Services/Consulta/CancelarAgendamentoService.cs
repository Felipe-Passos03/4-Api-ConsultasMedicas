using _4_Api_ConsultasMedicas.Application.DTOs.Consulta;
using _4_Api_ConsultasMedicas.Application.Interfaces.Consulta;
using _4_Api_ConsultasMedicas.Domain.Models.Enum.ConsultaEnum;
using _4_Api_ConsultasMedicas.Infra.Repository.Consulta;
using FluentResults;

namespace _4_Api_ConsultasMedicas.Application.Services.Consulta;

public class CancelarAgendamentoService : ICancelarAgendamentoService
{
    private readonly IConsultaRepository  _consultaRepository;

    public CancelarAgendamentoService(IConsultaRepository consultaRepository)
    {
        _consultaRepository = consultaRepository;
    }
    
    public async Task<Result> CancelarAgendamento(CancelarAgendamentoRequest request)
    {
        try
        {
            var agendamento = await _consultaRepository.GetConsultaById(request.IdConsulta);

            if (agendamento == null)
                return Result.Fail("Esse agendamento não existe");
            
            if (agendamento.Status == StatusConsulta.Cancelada ||  agendamento.Status == StatusConsulta.Finalizada)
                return Result.Fail("Só é possível cancelar a consulta caso ela esteja com o status -Agendada-.");
            
            var dataAtual = DateTime.Now;
            var dataHoraConsulta = agendamento.DataConsulta.ToDateTime(agendamento.HorarioConsulta);

            if (dataHoraConsulta < dataAtual.AddHours(24))
                return Result.Fail("A consulta só pode ser cancelada com no mínimo 24 horas de antecedência");
            
            agendamento.CancelarConsulta(request.Motivo);
            
            await _consultaRepository.SaveChangesAsync();
            
            return Result.Ok();
        }
        catch (Exception e)
        {
            return Result.Fail(e.Message);
        }
    }
}