using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudEscuela.Migrations
{
    /// <inheritdoc />
    public partial class _1805202303 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EliminadoAlumno",
                table: "Alumno",
                newName: "Eliminado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Eliminado",
                table: "Alumno",
                newName: "EliminadoAlumno");
        }
    }
}
