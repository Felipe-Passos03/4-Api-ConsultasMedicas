using _4_Api_ConsultasMedicas.Application.DTOs.Consulta;
using _4_Api_ConsultasMedicas.Application.Interfaces.Consulta;
using _4_Api_ConsultasMedicas.Domain.Models.Entity;
using _4_Api_ConsultasMedicas.Domain.Models.Enum.ConsultaEnum;
using _4_Api_ConsultasMedicas.Infra.Repository.Consulta;
using _4_Api_ConsultasMedicas.Infra.Repository.Medico;
using _4_Api_ConsultasMedicas.Infra.Repository.Paciente;
using FluentResults;

namespace _4_Api_ConsultasMedicas.Application.Services.Consulta;

public class CreateAgendamentoService : ICreateAgendamentoService
{
    private readonly IConsultaRepository  _consultaRepository;
    private readonly IPacienteRepository  _pacienteRepository;
    private readonly IMedicoRepository  _medicoRepository;

    public CreateAgendamentoService(IConsultaRepository consultaRepository,
                                    IPacienteRepository pacienteRepository,
                                    IMedicoRepository medicoRepository)
    {
        _consultaRepository = consultaRepository;
        _pacienteRepository = pacienteRepository;
        _medicoRepository = medicoRepository;
    }
    public async Task<Result<CreateAgendamentoResponse>> CreateAgendamento(CreateAgendamentoRequest request)
    {
        try
        {
            var pacienteExists = await _pacienteRepository.GetById(request.pacienteId);
            if (pacienteExists == null)
                return Result.Fail("Esse paciente não existe");
            
            
            var pacienteIsInadimplente = await _pacienteRepository.IsInadimplente(request.pacienteId);
            if (pacienteIsInadimplente)
                return Result.Fail("O paciente está inadimplente e não pode agendar consulta");
            
            
            if (request.DataConsulta <= DateOnly.FromDateTime(DateTime.Now))
                return Result.Fail("Data inválida");
            
            if (request.DataConsulta.DayOfWeek is (DayOfWeek.Saturday or DayOfWeek.Sunday))
                return Result.Fail("Somente dias úteis são permitidos");

            if (request.HorarioConsulta < new TimeOnly(8, 0) || request.HorarioConsulta > new TimeOnly(18, 30))
                return Result.Fail("Horários permitidos: das 08:00 às 18:30");

            if (request.HorarioConsulta.Minute != 0 && request.HorarioConsulta.Minute != 30)
                return Result.Fail(
                    "Horário inválido. Só é permitido agendar em horários de 30 em 30 minutos ex: 10:00 ou 10:30");
            
            
            var especialidade = await _medicoRepository.BuscarByEspecialidade(request.Especialidade);
            if (especialidade.Count == 0)
                return Result.Fail("Nenhum profissional encontrado para essa especialidade");
            
            
            var medicoAvaliable = await _medicoRepository.GetMedicoAvaliable(request.Especialidade,
                request.DataConsulta, request.HorarioConsulta);
            if (medicoAvaliable is null)
                return Result.Fail($"Vagas lotadas, não há nenhum profissional disponível para este horário");
            

            //Arrumar esse método, está retornando o nome errado do médico
            var consultaDuplicada = await _consultaRepository.ConsultaDuplicada
                (request.pacienteId, request.Especialidade, request.DataConsulta);
            if(consultaDuplicada)
                return Result.Fail($"Você já possuí uma consulta marcada com o(a) médico(a) {medicoAvaliable.Nome} no dia {request.DataConsulta}");
            

            var agendamento = new ConsultaEntity
                (request.pacienteId, medicoAvaliable.MedicoId, request.DataConsulta, request.HorarioConsulta, request.Especialidade);
            
            await _consultaRepository.CreateConsulta(agendamento);
            await _consultaRepository.SaveChangesAsync();

            var response = new CreateAgendamentoResponse
            {
                MedicoId = medicoAvaliable.MedicoId,
                PacienteId = request.pacienteId,
                DataConsulta = request.DataConsulta,
                HorarioConsulta = request.HorarioConsulta,
                Especialidade = request.Especialidade,
                Status = StatusConsulta.Agendada
            };
            
            return Result.Ok(response);

        }
        catch (Exception e)
        {
            return Result.Fail<CreateAgendamentoResponse>($"Erro ao criar agendamento {e.Message}");
        }
    }
}