using _4_Api_ConsultasMedicas.Domain.Models.Entity;
using FluentResults;

namespace _4_Api_ConsultasMedicas.Application.Interfaces.Consulta;

public interface IGetAgendamentoByPacienteService
{
    public Task<Result<List<ConsultaEntity>>> GetConsultasByPaciente(Guid pacienteId);
}