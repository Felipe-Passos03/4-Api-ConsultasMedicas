using _4_Api_ConsultasMedicas.Application.DTOs.Medico;
using FluentResults;

namespace _4_Api_ConsultasMedicas.Application.Interfaces.Medico;

public interface IUpdateMedicoService
{
    public Task<Result<UpdateMedicoResponse>> UpdateMedico(UpdateMedicoRequest request);
}