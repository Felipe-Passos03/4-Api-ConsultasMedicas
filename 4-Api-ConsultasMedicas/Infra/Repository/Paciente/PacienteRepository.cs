using _4_Api_ConsultasMedicas.Domain.Models.Entity;
using _4_Api_ConsultasMedicas.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace _4_Api_ConsultasMedicas.Infra.Repository.Paciente;

public class PacienteRepository : IPacienteRepository
{
    private readonly AppDbContext _context;

    public PacienteRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task Create(PacienteEntity paciente)
    {
        await _context.Pacientes.AddAsync(paciente);
    }

    public async Task<PacienteEntity> GetById(Guid id)
    {
        return await _context.Pacientes.FindAsync(id);
    }

    public async Task<List<PacienteEntity>> GetAll()
    {
        return _context.Pacientes.ToList();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<PacienteEntity> GetByCpf(string cpf)
    {
        return await _context.Pacientes.FirstOrDefaultAsync(paciente => paciente.CPF == cpf);
    }

    public async Task<bool> IsInadimplente(Guid id)
    {
        return await _context.Pacientes
            .Where(p => p.PacienteId == id)
            .Select(p => p.EstaInadimplente)
            .SingleAsync();
    }
}