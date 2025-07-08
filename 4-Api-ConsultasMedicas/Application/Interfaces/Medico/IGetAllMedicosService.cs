using _4_Api_ConsultasMedicas.Domain.Models.Entity;
using FluentResults;

namespace _4_Api_ConsultasMedicas.Application.Interfaces.Medico;

public interface IGetAllMedicosService
{
    public Task<Result<List<MedicoEntity>>> GetAllMedicos();
}