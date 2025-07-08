using _4_Api_ConsultasMedicas.Application.DTOs.Paciente;
using _4_Api_ConsultasMedicas.Application.Interfaces.Paciente;
using Microsoft.AspNetCore.Mvc;

namespace _4_Api_ConsultasMedicas.Application.Controllers;

[ApiController]
[Route("ConsultasMedicas/paciente")]
public class PacienteController : ControllerBase
{
    
    private readonly ICreatePacienteService _createpacienteService;
    private readonly IGetPacienteByIdService _getPacienteByIdService;
    private readonly IGetAllPacienteService _getAllPacienteService;
    private readonly IUpdatePacienteService _updatePacienteService;
    private readonly IAlterarStatusPacienteService _alterarStatusPacienteService;

    public PacienteController(ICreatePacienteService createpacienteService,
                             IGetPacienteByIdService getPacienteByIdService,
                             IGetAllPacienteService getAllPacienteService,
                             IUpdatePacienteService updatePacienteService,
                             IAlterarStatusPacienteService alterarStatusPacienteService) 
    {
        _createpacienteService = createpacienteService;
        _getPacienteByIdService = getPacienteByIdService;
        _getAllPacienteService = getAllPacienteService;
        _updatePacienteService = updatePacienteService;
        _alterarStatusPacienteService = alterarStatusPacienteService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreatePacienteAsync([FromBody] CreatePacienteRequest request)
    {
        var result = await _createpacienteService.CreatePaciente(request);
        
        if(result.IsFailed)
            return BadRequest(result.Errors.First().Message);
        
        return Ok(result.Value);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result  = await _getPacienteByIdService.GetById(id);
        if(result.IsFailed)
            return BadRequest(result.Errors.First().Message);
        
        return Ok(result.Value);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _getAllPacienteService.GetAll();
        
        if(result.IsFailed)
            return BadRequest(result.Errors.First().Message);
        
        return Ok(result.Value);
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePacienteAsync([FromBody] UpdatePacienteRequest request)
    {
        var result = await _updatePacienteService.UpdatePaciente(request);
        
        if(result.IsFailed)
            return BadRequest(result.Errors.First().Message);
        
        return Ok(result.Value);
    }

    [HttpPatch]
    [Route("invalidar/{id}")]
    public async Task<IActionResult> AlterarStatusPacienteAsync(Guid id)
    {
        var result = await _alterarStatusPacienteService.AlterarStatusPaciente(id);
        
        if(result.IsFailed)
            return BadRequest(result.Errors.First().Message);
        
        return Ok("Esse paciente agora está inadimplente");
    }
    
}