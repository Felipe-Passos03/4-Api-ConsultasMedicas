using _4_Api_ConsultasMedicas.Application.DTOs.Consulta;
using FluentResults;

namespace _4_Api_ConsultasMedicas.Application.Interfaces.Consulta;

public interface ICancelarAgendamentoService
{
    public Task<Result> CancelarAgendamento(CancelarAgendamentoRequest request);
}