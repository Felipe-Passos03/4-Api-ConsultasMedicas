namespace _4_Api_ConsultasMedicas.Domain.Models.Entity;

public class AdminEntity
{
    public Guid AdminId { get; init; }
    public string Email { get; private set; }
    public string Senha { get; private set; }

    public AdminEntity(string email, string senha)
    {
        AdminId = Guid.NewGuid();
        Email = email;
        Senha = senha;
    }
}