using System.Text.Json.Serialization;

namespace _4_Api_ConsultasMedicas.Domain.Models.Entity;

public class PacienteEntity
{
    public Guid PacienteId { get; init; }
    public string Nome { get; private set; }
    public string CPF { get; private set; }
    public bool EstaInadimplente { get; private set; }
    
    [JsonIgnore]
    public List<ConsultaEntity> Consultas { get; private set; } = new();
    
    public PacienteEntity(string nome , string cpf)
    {
        PacienteId = Guid.NewGuid();
        Nome = nome;
        CPF = cpf;
        EstaInadimplente = false;
    }

    public void Atualizar(string nome)
    {
        Nome = nome;
    }

    public void AlterarStatus()
    {
        EstaInadimplente = true;
    }
    
    
    private PacienteEntity()
    {
        
    }
}