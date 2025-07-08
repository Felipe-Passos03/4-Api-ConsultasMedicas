using _4_Api_ConsultasMedicas.Application.DTOs.Medico;
using FluentResults;

namespace _4_Api_ConsultasMedicas.Application.Interfaces.Medico;

public interface ICreateMedicoService
{
    public Task<Result<CreateMedicoResponse>> CreateAsync(CreateMedicoRequest medicoRequest);
}