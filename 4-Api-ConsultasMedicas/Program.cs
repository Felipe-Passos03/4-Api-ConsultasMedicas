using _4_Api_ConsultasMedicas.Application.Interfaces.Admin;
using _4_Api_ConsultasMedicas.Application.Interfaces.Auth;
using _4_Api_ConsultasMedicas.Application.Interfaces.Consulta;
using _4_Api_ConsultasMedicas.Application.Interfaces.Medico;
using _4_Api_ConsultasMedicas.Application.Interfaces.Paciente;
using _4_Api_ConsultasMedicas.Application.Services.Admin;
using _4_Api_ConsultasMedicas.Application.Services.Auth;
using _4_Api_ConsultasMedicas.Application.Services.Consulta;
using _4_Api_ConsultasMedicas.Application.Services.Medico;
using _4_Api_ConsultasMedicas.Application.Services.Paciente;
using _4_Api_ConsultasMedicas.Domain.Models.Services.Jwt;
using _4_Api_ConsultasMedicas.Infra.Data;
using _4_Api_ConsultasMedicas.Infra.Repository.Admin;
using _4_Api_ConsultasMedicas.Infra.Repository.Consulta;
using _4_Api_ConsultasMedicas.Infra.Repository.Medico;
using _4_Api_ConsultasMedicas.Infra.Repository.Paciente;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddJwtAuthentication(builder.Configuration);

//AllRepos
builder.Services.AddScoped<IAdminRepository , AdminRepository>();
builder.Services.AddScoped<IMedicoRepository, MedicoRepository>();
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<IConsultaRepository, ConsultaRepository>();

//AdminServices
builder.Services.AddScoped<ICreateAdminService, CreateAdminService>();
builder.Services.AddScoped<IGetAdminByIdService, GetAdminByIdService>();
builder.Services.AddScoped<IDeleteAdminById,  DeleteAdminByIdService>();
builder.Services.AddScoped<ILoginAdminService, LoginAdminAdminService>();

//MedicoServices
builder.Services.AddScoped<ICreateMedicoService, CreateMedicoService>();
builder.Services.AddScoped<IValidarCrmService, ValidarCrmService>();
builder.Services.AddScoped<IGetMedicoByIdService, GetMedicoByIdService>();
builder.Services.AddScoped<IGetAllMedicosService, GetAllMedicosService>();
builder.Services.AddScoped<IUpdateMedicoService, UpdateMedicoService>();
builder.Services.AddScoped<IInativarMedicoService, InativarMedicoService>();

//PacienteServices
builder.Services.AddScoped<ICreatePacienteService, CreatePacienteService>();
builder.Services.AddScoped<IGetPacienteByIdService, GetPacienteByIdService>();
builder.Services.AddScoped<IGetAllPacienteService, GetAllPacienteService>();
builder.Services.AddScoped<IUpdatePacienteService, UpdatePacienteService>();
builder.Services.AddScoped<IAlterarStatusPacienteService, AlterarStatusPacienteService>();

//ConsultaServices
builder.Services.AddScoped<ICreateAgendamentoService, CreateAgendamentoService>();
builder.Services.AddScoped<IGetAllAgendamentosService, GetAllAgendamentosService>();
builder.Services.AddScoped<IGetAgendamentoByPacienteService, GetAgendamentoByPacienteService>();
builder.Services.AddScoped<IGetAgendamentoByMedicoService, GetAgendamentoByMedicoService>();
builder.Services.AddScoped<ICancelarAgendamentoService, CancelarAgendamentoService>();
builder.Services.AddScoped<IFinalizarAgendamentoService, FinalizarAgendamentoService>();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite
        (builder.Configuration.GetConnectionString("DefaultConnection"))
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors()
    .LogTo(Console.WriteLine, LogLevel.Error));;

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

