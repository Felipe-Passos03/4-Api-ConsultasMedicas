using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using _4_Api_ConsultasMedicas.Application.Validators;

namespace _4_Api_ConsultasMedicas.Application.DTOs.Consulta;

public class CreateAgendamentoRequest
{
    [Required(ErrorMessage = "O campo id paciente é obrigatório")]
    public Guid pacienteId { get; set; }
    
    [Required(ErrorMessage = "O campo data consulta é obrigatório")]
    [JsonConverter(typeof(DateOnlyJsonConverter))]
    public DateOnly DataConsulta { get; set; }
    
    [Required(ErrorMessage = "O campo horário consulta é obrigatório")]
    [JsonConverter(typeof(TimeOnlyJsonConverter))]
    public TimeOnly HorarioConsulta { get;  set; }
    
    [Required(ErrorMessage = "O campo especialidade é obrigatório")]
    public string Especialidade { get; set; }
}