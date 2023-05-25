using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudEscuela.Migrations
{
    /// <inheritdoc />
    public partial class _18052023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EliminadoAlumno",
                table: "Alumno",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EliminadoAlumno",
                table: "Alumno");
        }
    }
}
