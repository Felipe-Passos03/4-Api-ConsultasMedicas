using _4_Api_ConsultasMedicas.Domain.Models.Entity;
using FluentResults;

namespace _4_Api_ConsultasMedicas.Application.Interfaces.Paciente;

public interface IGetPacienteByIdService
{
    public Task<Result<PacienteEntity>>  GetById(Guid id);
}