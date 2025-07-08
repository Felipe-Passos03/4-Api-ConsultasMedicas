namespace _4_Api_ConsultasMedicas.Application.Validators;

public static class PasswordEncryptor
{
    public static string Encriptor(string senha)
    {
        return BCrypt.Net.BCrypt.HashPassword(senha);
    }
}