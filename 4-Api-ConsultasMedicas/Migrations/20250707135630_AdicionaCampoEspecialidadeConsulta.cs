using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4_Api_ConsultasMedicas.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaCampoEspecialidadeConsulta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Especialidade",
                table: "Consultas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Especialidade",
                table: "Consultas");
        }
    }
}
