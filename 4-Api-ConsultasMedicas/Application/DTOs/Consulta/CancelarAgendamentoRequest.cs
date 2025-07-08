using System.ComponentModel.DataAnnotations;

namespace _4_Api_ConsultasMedicas.Application.DTOs.Consulta;

public class CancelarAgendamentoRequest
{
    [Required(ErrorMessage = "Obrigatório id da consulta")]
    public Guid IdConsulta { get; set; }
    
    [Required(ErrorMessage = "Obrigatório motivo cancelamento")]
    public string Motivo { get; set; }
}