using _4_Api_ConsultasMedicas.Application.DTOs.Paciente;
using _4_Api_ConsultasMedicas.Domain.Models.Entity;
using FluentResults;

namespace _4_Api_ConsultasMedicas.Application.Interfaces.Paciente;

public interface ICreatePacienteService
{
    public Task<Result<CreatePacienteResponse>> CreatePaciente(CreatePacienteRequest request);
}