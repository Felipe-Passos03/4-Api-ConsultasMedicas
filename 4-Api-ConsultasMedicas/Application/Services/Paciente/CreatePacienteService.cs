using _4_Api_ConsultasMedicas.Application.DTOs.Paciente;
using _4_Api_ConsultasMedicas.Application.Interfaces.Paciente;
using _4_Api_ConsultasMedicas.Application.Validators;
using _4_Api_ConsultasMedicas.Domain.Models.Entity;
using _4_Api_ConsultasMedicas.Infra.Repository.Paciente;
using FluentResults;

namespace _4_Api_ConsultasMedicas.Application.Services.Paciente;

public class CreatePacienteService : ICreatePacienteService
{
    private readonly IPacienteRepository _pacienteRepository;

    public CreatePacienteService(IPacienteRepository pacienteRepository)
    {
        _pacienteRepository = pacienteRepository;
    }
    
    public async Task<Result<CreatePacienteResponse>> CreatePaciente(CreatePacienteRequest request)
    {
        try
        {
            var paciente = await _pacienteRepository.GetByCpf(request.CPF);
     
            if (paciente != null)
                return Result.Fail("Já existe um paciente registrado com esse CPF");
        
            var CpfIsValid = CpfValidator.IsValid(request.CPF);
        
            if (!CpfIsValid)
                return Result.Fail("CPF invalido");

            var result = new PacienteEntity(request.Nome, request.CPF);
        
            await _pacienteRepository.Create(result);
            await _pacienteRepository.SaveChangesAsync();

            var response = new CreatePacienteResponse
            {
                id = result.PacienteId,
                Nome = result.Nome,
                CPF = result.CPF,
                EstaInadimplente = result.EstaInadimplente,
            };
        
            return Result.Ok(response);
        }
        catch (Exception e)
        {
            return Result.Fail(e.Message);
        }
    }
}