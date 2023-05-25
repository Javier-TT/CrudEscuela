using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudEscuela.Migrations
{
    /// <inheritdoc />
    public partial class _05052023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Alumno",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Alumno");
        }
    }
}
