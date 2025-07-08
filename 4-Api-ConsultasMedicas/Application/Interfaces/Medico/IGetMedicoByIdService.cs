using _4_Api_ConsultasMedicas.Domain.Models.Entity;
using FluentResults;

namespace _4_Api_ConsultasMedicas.Application.Interfaces.Medico;

public interface IGetMedicoByIdService
{
    public Task<Result<MedicoEntity>> GetMedicoById(Guid id);
}