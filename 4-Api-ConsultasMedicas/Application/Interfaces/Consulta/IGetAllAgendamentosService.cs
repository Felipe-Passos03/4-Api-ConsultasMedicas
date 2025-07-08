using _4_Api_ConsultasMedicas.Application.DTOs.Consulta;
using _4_Api_ConsultasMedicas.Domain.Models.Entity;
using FluentResults;

namespace _4_Api_ConsultasMedicas.Application.Interfaces.Consulta;

public interface IGetAllAgendamentosService
{
    public Task<Result<List<ConsultaEntity>>> GetAllAgendamentos(OffSetLimitRequest offSetLimitrequest);
}