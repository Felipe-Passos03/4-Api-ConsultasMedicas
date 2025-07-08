using System.Text.Json.Serialization;

namespace _4_Api_ConsultasMedicas.Domain.Models.Entity;

public class MedicoEntity
{
    public Guid MedicoId { get; init; }
    public string Nome { get; private set; }
    public string Especialidade { get; private set; }
    public string CRM { get; private set; }
    public bool Ativo { get; private set; }
    
    [JsonIgnore]
    public List<ConsultaEntity> Consultas { get; private set; } = new();

    private MedicoEntity()
    {
        
    }

    public MedicoEntity(string nome , string especialidade, string crm)
    {
        MedicoId = Guid.NewGuid();
        Nome = nome;
        Especialidade = especialidade;
        CRM = crm;
        Ativo = true;
    }

    public void AtualizarMedico(string nome, string especialidade)
    {
        Nome = nome;
        Especialidade = especialidade;
    }

    public void AtualizarStatus()
    {
        Ativo = false;
    }
}