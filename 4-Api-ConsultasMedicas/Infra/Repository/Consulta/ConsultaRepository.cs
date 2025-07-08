using _4_Api_ConsultasMedicas.Domain.Models.Entity;
using _4_Api_ConsultasMedicas.Domain.Models.Enum.ConsultaEnum;
using _4_Api_ConsultasMedicas.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace _4_Api_ConsultasMedicas.Infra.Repository.Consulta;

public class ConsultaRepository :  IConsultaRepository
{
    private readonly AppDbContext _context;

    public ConsultaRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task CreateConsulta(ConsultaEntity? consulta)
    {
        await _context.Consultas.AddAsync(consulta);
    }

    public async Task<List<ConsultaEntity>> GetAllAgendamentosOffSetLimit(int limit, int offset)
    {
        return await _context.Consultas
            .Include(c => c.Medico)
            .Include(c => c.Paciente)
            .OrderBy(c => c.DataConsulta)
            .Skip(offset)
            .Take(limit)
            .ToListAsync();
    }

    public async Task<int> ContarTotal()
    {
        return await _context.Consultas.CountAsync();
    }

    public async Task<List<ConsultaEntity>> GetAgendamentoByPacienteId(Guid pacienteId)
    {
        return await _context.Consultas
            .Include(c => c.Medico)
            .Include(c => c.Paciente)
            .Where(consulta => consulta.PacienteId == pacienteId)
            .Where(consulta => consulta.Status == StatusConsulta.Agendada)
            .OrderBy(c => c.DataConsulta)
            .ToListAsync();
    }

    public async Task<List<ConsultaEntity>> GetAgendamentoByMedicoId(Guid medicoId)
    {
        return await _context.Consultas
            .Include(c => c.Paciente)
            .Include(c => c.Medico)
            .OrderBy(c => c.DataConsulta)
            .Where(consulta => consulta.MedicoId == medicoId).ToListAsync();
    }

    public async Task<bool> ConsultaDuplicada(Guid pacienteId,string especialidade, DateOnly dataConsulta)
    {
        return await _context.Consultas.AnyAsync(c =>
            c.PacienteId == pacienteId &&
            c.Especialidade.ToLower() == especialidade.ToLower() &&
            c.DataConsulta == dataConsulta &&
            c.Status == StatusConsulta.Agendada
        );
    }

    public async Task<ConsultaEntity?> GetConsultaById(Guid consultaId)
    {
        return await _context.Consultas.FindAsync(consultaId);
          
    }

    public async Task SaveChangesAsync()
    {
        await  _context.SaveChangesAsync();
    }

    
}