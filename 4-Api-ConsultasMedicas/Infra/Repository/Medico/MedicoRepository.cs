using _4_Api_ConsultasMedicas.Domain.Models.Entity;
using _4_Api_ConsultasMedicas.Domain.Models.Enum.ConsultaEnum;
using _4_Api_ConsultasMedicas.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace _4_Api_ConsultasMedicas.Infra.Repository.Medico;

public class MedicoRepository : IMedicoRepository
{
    
    private readonly AppDbContext _context;

    public MedicoRepository(AppDbContext context)
    {
        _context = context;
    }
        
    public async Task Create(MedicoEntity medico)
    {
        await  _context.Medicos.AddAsync(medico);
    }

    public async Task<MedicoEntity> GetById(Guid id)
    {
        return await _context.Medicos.FindAsync(id);
    }

    public async Task<List<MedicoEntity>> GetAll()
    {
        return await _context.Medicos.ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<MedicoEntity> FindCrm(string crm)
    {
        return await _context.Medicos.FirstOrDefaultAsync(medico => medico.CRM == crm);
    }

    public async Task<MedicoEntity?> GetMedicoAvaliable(string especialidade, DateOnly dataConsulta, TimeOnly horaConsulta)
    {
        return await _context.Medicos
            .Include(m => m.Consultas)
            .Where(m => m.Especialidade.ToLower().Trim() == especialidade.ToLower().Trim())
            .Where(m => m.Ativo)
            .Where(m => !m.Consultas.Any(c =>
                c.DataConsulta == dataConsulta &&
                c.HorarioConsulta == horaConsulta &&
                c.Status == StatusConsulta.Agendada))
            .FirstOrDefaultAsync();
    }

    public async Task<List<MedicoEntity>> BuscarByEspecialidade(string especialidade)
    {
        return await _context.Medicos
            .Where(m => m.Ativo) // opcional: filtra apenas médicos ativos
            .Where(m => m.Especialidade.ToLower().Trim() == especialidade.ToLower().Trim())
            .ToListAsync();
    }
    
}