using FluentResults;

namespace _4_Api_ConsultasMedicas.Application.Interfaces.Medico;

public interface IInativarMedicoService
{
    public Task<Result> Inativar(Guid id);
}