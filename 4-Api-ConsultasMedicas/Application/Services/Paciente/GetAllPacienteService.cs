using _4_Api_ConsultasMedicas.Application.Interfaces.Paciente;
using _4_Api_ConsultasMedicas.Domain.Models.Entity;
using _4_Api_ConsultasMedicas.Infra.Repository.Paciente;
using FluentResults;

namespace _4_Api_ConsultasMedicas.Application.Services.Paciente;

public class GetAllPacienteService : IGetAllPacienteService
{
    private readonly IPacienteRepository _pacienteRepository;

    public GetAllPacienteService(IPacienteRepository pacienteRepository)
    {
        _pacienteRepository = pacienteRepository;
    }
    
    public async Task<Result<List<PacienteEntity>>> GetAll()
    {
        try
        {
            var getAll = await _pacienteRepository.GetAll();

            if (getAll.Count == 0)
                return Result.Fail("Lista vazia");
            
            return (getAll);
        }
        catch (Exception e)
        {
            return Result.Fail(e.Message);
        }
    }
}