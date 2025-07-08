using _4_Api_ConsultasMedicas.Application.DTOs.Consulta;
using FluentResults;

namespace _4_Api_ConsultasMedicas.Application.Interfaces.Consulta;

public interface ICreateAgendamentoService
{
    public Task<Result<CreateAgendamentoResponse>> CreateAgendamento(CreateAgendamentoRequest request);
}