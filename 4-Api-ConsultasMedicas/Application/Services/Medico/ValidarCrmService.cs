using System.Text.RegularExpressions;
using _4_Api_ConsultasMedicas.Application.Interfaces.Medico;

namespace _4_Api_ConsultasMedicas.Application.Services.Medico;

public class ValidarCrmService : IValidarCrmService
{
    public bool ValidarCrm(string crm)
    {
        return Regex.IsMatch(crm, @"^CRM\/[A-Z]{2} \d{6}$"); 
        
        /*
         * ^ → Início da string

                CRM\/ → Literal CRM/ (a barra é escapada com \)

                [A-Z]{2} → Duas letras maiúsculas (estado)

                → Espaço

                \d{6} → Seis dígitos

                $ → Fim da string
         */
    }
}