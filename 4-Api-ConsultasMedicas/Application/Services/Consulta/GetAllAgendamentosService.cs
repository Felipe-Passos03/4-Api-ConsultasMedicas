using _4_Api_ConsultasMedicas.Application.DTOs.Consulta;
using _4_Api_ConsultasMedicas.Application.Interfaces.Consulta;
using _4_Api_ConsultasMedicas.Domain.Models.Entity;
using _4_Api_ConsultasMedicas.Infra.Repository.Consulta;
using FluentResults;

namespace _4_Api_ConsultasMedicas.Application.Services.Consulta;

public class GetAllAgendamentosService :  IGetAllAgendamentosService
{
    private readonly IConsultaRepository _consultaRepository;

    public GetAllAgendamentosService(IConsultaRepository consultaRepository)
    {
        _consultaRepository = consultaRepository;
    }
    
    public async Task<Result<List<ConsultaEntity>>> GetAllAgendamentos(OffSetLimitRequest request)
    {
        try
        {
            var agendamentos = await _consultaRepository.GetAllAgendamentosOffSetLimit(request.Limit, request.Offset);
        
            if(agendamentos.Count() == 0)
                return Result.Fail<List<ConsultaEntity>>("Lista de agendamentos está vazia");
            
            
            return Result.Ok(agendamentos);
        }
        catch (Exception e)
        {
           return  Result.Fail<List<ConsultaEntity>>(e.Message);
        }
       
    }
}