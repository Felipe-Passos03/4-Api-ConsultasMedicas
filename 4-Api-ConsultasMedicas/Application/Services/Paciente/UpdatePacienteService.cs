using _4_Api_ConsultasMedicas.Application.DTOs.Paciente;
using _4_Api_ConsultasMedicas.Application.Interfaces.Paciente;
using _4_Api_ConsultasMedicas.Infra.Repository.Paciente;
using FluentResults;

namespace _4_Api_ConsultasMedicas.Application.Services.Paciente;

public class UpdatePacienteService : IUpdatePacienteService
{
    private readonly IPacienteRepository _pacienteRepository;

    public UpdatePacienteService(IPacienteRepository pacienteRepository)
    {
        _pacienteRepository = pacienteRepository;
    }
    
    public async Task<Result<UpdatePacienteResponse>> UpdatePaciente(UpdatePacienteRequest request)
    {
        try
        {
            var getPaciente = await _pacienteRepository.GetById(request.IdPaciente);

            if (getPaciente == null)
                return Result.Fail<UpdatePacienteResponse>("Esse paciente não existe");

            getPaciente.Atualizar(request.Nome);
            await _pacienteRepository.SaveChangesAsync();
         
            var response = new UpdatePacienteResponse
            {
                idMedico = getPaciente.PacienteId,
                Nome = getPaciente.Nome,
                CPF = getPaciente.CPF,
                EstaInadimplente = getPaciente.EstaInadimplente,
             
            };
            return Result.Ok(response);
        }
        catch (Exception e)
        {
            return  Result.Fail<UpdatePacienteResponse>(e.Message);
        }
    }
}