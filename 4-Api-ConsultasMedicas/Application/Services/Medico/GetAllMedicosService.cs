using _4_Api_ConsultasMedicas.Application.Interfaces.Medico;
using _4_Api_ConsultasMedicas.Domain.Models.Entity;
using _4_Api_ConsultasMedicas.Infra.Repository.Medico;
using FluentResults;

namespace _4_Api_ConsultasMedicas.Application.Services.Medico;

public class GetAllMedicosService :  IGetAllMedicosService
{
    private readonly IMedicoRepository _medicoRepository;

    public GetAllMedicosService(IMedicoRepository medicoRepository)
    {
        _medicoRepository = medicoRepository;
    }
    public async Task<Result<List<MedicoEntity>>> GetAllMedicos()
    {
        try
        {
            var getAllMedicosResult = await _medicoRepository.GetAll();

            if (getAllMedicosResult == null)
                return Result.Fail("Lista vazia");
            
            return getAllMedicosResult;
        }
        catch (Exception e)
        {
           return Result.Fail<List<MedicoEntity>>(e.Message);
        }
    }
}