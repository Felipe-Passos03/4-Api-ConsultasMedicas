using _4_Api_ConsultasMedicas.Application.DTOs.Admin;
using _4_Api_ConsultasMedicas.Application.DTOs.Auth;
using _4_Api_ConsultasMedicas.Application.Interfaces.Admin;
using _4_Api_ConsultasMedicas.Application.Interfaces.Auth;
using _4_Api_ConsultasMedicas.Domain.Models.Entity;
using _4_Api_ConsultasMedicas.Infra.Repository.Admin;
using FluentResults;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace _4_Api_ConsultasMedicas.Application.Controllers;

[ApiController]
[Route("ConsultasMedicas/admin")]
public class AdminController : ControllerBase
{
    private readonly ICreateAdminService  _createAdminService;
    private readonly IGetAdminByIdService  _getAdminByIdService;
    private readonly IDeleteAdminById  _deleteAdminByIdService;
    private readonly ILoginAdminService  _loginAdminService;

    
    public AdminController(ICreateAdminService createAdminService, 
                            IGetAdminByIdService getAdminByIdService,
                            IDeleteAdminById  deleteAdminByIdService,
                            ILoginAdminService loginAdminService)
    {
        _createAdminService = createAdminService;
        _getAdminByIdService = getAdminByIdService;
        _deleteAdminByIdService = deleteAdminByIdService;
        _loginAdminService = loginAdminService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAdmin([FromBody] CreateAdminRequest request)
    {
        var result = await _createAdminService.CreateAdmin(request);
        
        if(result.IsFailed)
            return BadRequest(result.Errors.First().Message);
        
        var response = result.Value;
        
        return CreatedAtAction(nameof(GetAdminById), new {id = response.AdminId}, response);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetAdminById(Guid id)
    {
        if(id == Guid.Empty)
            return BadRequest("Não é permitido id nulo");
        
        var result = await _getAdminByIdService.GetAdminById(id);
        
        if (result.IsFailed)
            return BadRequest(result.Errors.First().Message);
        
        return Ok(result.Value);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteAdminById(Guid id)
    {
        if(id == Guid.Empty)
            return BadRequest("Não é permitido id nulo");
        
        var result = await _deleteAdminByIdService.DeleteAdminById(id);
        
        if (result.IsFailed)
            return BadRequest(result.Errors.First().Message);
        
        return Ok("Admin removido com sucesso");
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> login([FromBody] LoginRequests loginRequest)
    {
        var login = await _loginAdminService.Login(loginRequest);
        
        if(login.IsFailed)
            return  BadRequest(login.Errors.First().Message);
        
        return Ok(login.Value);
    }
}