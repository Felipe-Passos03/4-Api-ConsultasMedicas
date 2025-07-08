using _4_Api_ConsultasMedicas.Application.DTOs.Paciente;
using FluentResults;

namespace _4_Api_ConsultasMedicas.Application.Interfaces.Paciente;

public interface IUpdatePacienteService
{
    public Task<Result<UpdatePacienteResponse>> UpdatePaciente(UpdatePacienteRequest request);
}