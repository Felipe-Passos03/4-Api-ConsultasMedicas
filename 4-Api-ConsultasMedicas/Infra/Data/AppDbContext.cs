using _4_Api_ConsultasMedicas.Domain.Models;
using _4_Api_ConsultasMedicas.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace _4_Api_ConsultasMedicas.Infra.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<ConsultaEntity?> Consultas { get; set; }
    public DbSet<MedicoEntity> Medicos { get; set; }
    public DbSet<PacienteEntity> Pacientes { get; set; }
    public DbSet<AdminEntity> Admins { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MedicoEntity>(entity =>
        {
            entity.HasKey(medico => medico.MedicoId);
            entity.Property(medico => medico.Nome).HasMaxLength(100).IsRequired();
            entity.Property(medico => medico.Especialidade).HasMaxLength(100).IsRequired();
            entity.Property(medico => medico.CRM).HasMaxLength(100).IsRequired();
        });
        
        modelBuilder.Entity<PacienteEntity>(entity =>
        {
            entity.HasKey(paciente => paciente.PacienteId);
            entity.Property(paciente => paciente.Nome).HasMaxLength(100).IsRequired();
            entity.Property(paciente => paciente.CPF).HasMaxLength(100).IsRequired();
            entity.Property(paciente => paciente.EstaInadimplente).IsRequired();
        });
        
        modelBuilder.Entity<AdminEntity>(entity =>
        {
            entity.HasKey(admin => admin.AdminId);
            entity.Property(admin => admin.Email).HasMaxLength(100).IsRequired();
            entity.Property(admin => admin.Senha).HasMaxLength(100).IsRequired();
        });

        modelBuilder.Entity<ConsultaEntity>(entity =>
        {
            entity.HasKey(consulta => consulta.ConsultaId);
            entity.Property(consulta => consulta.MedicoId).IsRequired();
            entity.Property(consulta => consulta.PacienteId).IsRequired();
            entity.Property(consulta => consulta.DataConsulta).IsRequired();
            entity.Property(consulta => consulta.HorarioConsulta).IsRequired();
            entity.Property(consulta => consulta.Especialidade).IsRequired();

        });

        modelBuilder.Entity<ConsultaEntity>()
            .HasOne(consulta => consulta.Medico)
            .WithMany(medicos => medicos.Consultas)
            .HasForeignKey(consulta => consulta.MedicoId)
            .OnDelete(DeleteBehavior.Restrict); 
        
        modelBuilder.Entity<ConsultaEntity>()
            .HasOne(consulta => consulta.Paciente)
            .WithMany(pacientes => pacientes.Consultas)
            .HasForeignKey(consulta => consulta.PacienteId)
            .OnDelete(DeleteBehavior.Restrict); 
        
        modelBuilder.Entity<ConsultaEntity>()
            .Property(consulta => consulta.DataConsulta)
            .HasConversion(
                data => data.ToDateTime(TimeOnly.MinValue),
                data => DateOnly.FromDateTime(data))
            .HasColumnName("DataConsulta");
        
        modelBuilder.Entity<ConsultaEntity>()
            .Property(consultas => consultas.HorarioConsulta)
            .HasConversion(
                v => v.ToTimeSpan(),             // TimeOnly → TimeSpan (salva no banco)
                v => TimeOnly.FromTimeSpan(v)    // TimeSpan → TimeOnly (recupera do banco)
            );
    }
}