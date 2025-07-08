using _4_Api_ConsultasMedicas.Application.DTOs.Consulta;
using _4_Api_ConsultasMedicas.Application.Interfaces.Consulta;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _4_Api_ConsultasMedicas.Application.Controllers;

[ApiController]
[Route("ConsultasMedicas/consultas")]
public class ConsultaController : ControllerBase
{
    private readonly ICreateAgendamentoService  _createAgendamentoService;
    private readonly IGetAllAgendamentosService  _getAllAgendamentosService;
    private readonly IGetAgendamentoByPacienteService  _getAgendamentoByPacienteService;
    private readonly IGetAgendamentoByMedicoService  _getAgendamentoByMedicoService;
    private readonly ICancelarAgendamentoService  _cancelarAgendamentoService;
    private readonly IFinalizarAgendamentoService  _finalizarAgendamentoService;

    public ConsultaController(ICreateAgendamentoService createAgendamentoService,
                                IGetAllAgendamentosService getAllAgendamentosService,
                                IGetAgendamentoByPacienteService getAgendamentoByPacienteService,
                                IGetAgendamentoByMedicoService getAgendamentoByMedicoService,
                                ICancelarAgendamentoService cancelarAgendamentoService,
                                IFinalizarAgendamentoService finalizarAgendamentoService)
    {
        _createAgendamentoService = createAgendamentoService;
        _getAllAgendamentosService = getAllAgendamentosService;
        _getAgendamentoByPacienteService = getAgendamentoByPacienteService;
        _getAgendamentoByMedicoService = getAgendamentoByMedicoService;
        _cancelarAgendamentoService = cancelarAgendamentoService;
        _finalizarAgendamentoService = finalizarAgendamentoService;
    }
    
    [HttpPost]
    public async Task<IActionResult> AgendarConsulta([FromBody] CreateAgendamentoRequest request)
    {
        var result = await _createAgendamentoService.CreateAgendamento(request);
        
        if(result.IsFailed)
            return BadRequest(result.Errors.First().Message);
        
        return Ok(result.Value);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllAgendamentos([FromQuery] OffSetLimitRequest request)
    {
        var result = await _getAllAgendamentosService.GetAllAgendamentos(request);
        
        if (result.IsFailed)
            return BadRequest(result.Errors.First().Message);
        
        return Ok(result.Value);
    }

    [HttpGet("paciente/{pacienteid}")]
    public async Task<IActionResult> GetAgendamentoByPaciente([FromRoute] Guid pacienteid)
    {
        var result = await _getAgendamentoByPacienteService.GetConsultasByPaciente(pacienteid);
        
        if (result.IsFailed)
            return BadRequest(result.Errors.First().Message);
        
        return Ok(result.Value);
    }

    [HttpGet("medico/{medicoid}")]
    public async Task<IActionResult> GetAgendamentoByMedico([FromRoute] Guid medicoid)
    {
        var result = await _getAgendamentoByMedicoService.GetAgendamentosByMedicoId(medicoid);
        
        if (result.IsFailed)
            return BadRequest(result.Errors.First().Message);
        
        return Ok(result.Value);
    }

    [HttpPatch]
    [Route("Cancelar")]
    public async Task<IActionResult> CancelarAgendamento([FromBody] CancelarAgendamentoRequest request)
    {
        var result = await _cancelarAgendamentoService.CancelarAgendamento(request);
        
        if (result.IsFailed)
            return BadRequest(result.Errors.First().Message);
        
        return Ok("Agendamento Cancelado");
    }

    [HttpPatch]
    [Route("Finalizar/{id}")]
    public async Task<IActionResult> FinalizarAgendamento([FromRoute] Guid id)
    {
        var result = await _finalizarAgendamentoService.FinalizarAgendamentoAsync(id);
        
        if (result.IsFailed)
            return BadRequest(result.Errors.First().Message);
        
        return Ok("Agendamento Finalizado");
    }
}