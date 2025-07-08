using _4_Api_ConsultasMedicas.Application.DTOs.Medico;
using FluentResults;

namespace _4_Api_ConsultasMedicas.Application.Interfaces.Consulta;

public interface IFinalizarAgendamentoService
{
    public Task<Result> FinalizarAgendamentoAsync(Guid id);
}