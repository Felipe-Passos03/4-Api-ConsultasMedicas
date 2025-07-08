
using FluentResults;

namespace _4_Api_ConsultasMedicas.Application.Interfaces.Paciente;

public interface IAlterarStatusPacienteService
{
    public Task<Result> AlterarStatusPaciente(Guid id);
}