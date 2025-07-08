using _4_Api_ConsultasMedicas.Domain.Models;
using _4_Api_ConsultasMedicas.Domain.Models.Entity;
using _4_Api_ConsultasMedicas.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace _4_Api_ConsultasMedicas.Infra.Repository.Admin;

public class AdminRepository : IAdminRepository
{
    private readonly AppDbContext _context;

    public AdminRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task Create(AdminEntity admin)
    {
        await _context.Admins.AddAsync(admin);
    }
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
    public async Task<bool> EmailAlreadExists(string email)
    {
        return await _context.Admins.AnyAsync(admin => admin.Email == email);
    }
    
    public async Task<AdminEntity> GetAdminById(Guid id)
    {
        return await _context.Admins.FindAsync(id);
    }

    public async Task RemoveAdminById(Guid id)
    {
        _context.Admins.Remove(await _context.Admins.FindAsync(id));
    }
}