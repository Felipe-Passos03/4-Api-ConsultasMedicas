using _4_Api_ConsultasMedicas.Application.DTOs.Medico;
using _4_Api_ConsultasMedicas.Application.Interfaces.Medico;
using Microsoft.AspNetCore.Mvc;

namespace _4_Api_ConsultasMedicas.Application.Controllers;


[ApiController]
[Route("ConsultasMedicas/medico")]
public class MedicoController : ControllerBase
{
    private readonly ICreateMedicoService _createMedicoService;
    private readonly IGetMedicoByIdService _getMedicoByIdService;
    private readonly IGetAllMedicosService _getAllMedicosService;
    private readonly IUpdateMedicoService _updateMedicoService;
    private readonly IInativarMedicoService _inativarMedicoService;

    public MedicoController(ICreateMedicoService createMedicoService, 
                            IGetMedicoByIdService getMedicoByIdService,
                            IGetAllMedicosService getAllMedicosService,
                            IUpdateMedicoService updateMedicoService,
                            IInativarMedicoService inativarMedicoService)
    {
        _createMedicoService = createMedicoService;
        _getMedicoByIdService = getMedicoByIdService;
        _getAllMedicosService = getAllMedicosService;
        _updateMedicoService = updateMedicoService;
        _inativarMedicoService = inativarMedicoService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMedicoRequest request)
    {
        var result = await _createMedicoService.CreateAsync(request);
        
        if(result.IsFailed)
            return BadRequest(result.Errors.First().Message);
        
        return Ok(result.Value);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetbyId(Guid id)
    {
        var result = await _getMedicoByIdService.GetMedicoById(id);
        
        if (result.IsFailed)
            return BadRequest(result.Errors.First().Message);
        
        return Ok(result.Value);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result  =  await _getAllMedicosService.GetAllMedicos();
        
        if (result.IsFailed)
            return BadRequest(result.Errors.First().Message);
        
        return Ok(result.Value);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateMedicoRequest request)
    {
        var result = await _updateMedicoService.UpdateMedico(request);
        
        if(result.IsFailed)
            return  BadRequest(result.Errors.First().Message);
        
        return Ok(result.Value);
    }

    [HttpPatch]
    [Route("inativar/{id}")]
    public async Task<IActionResult> InativarMedico(Guid id)
    {
        var result = await _inativarMedicoService.Inativar(id);
        
        if(result.IsFailed)
            return BadRequest("Falha ao inativar médico");
        
        return Ok("Médico inativado com sucesso");
    }
}