using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RelationsApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Users",
                newName: "Lastname");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "Firstname");

            migrationBuilder.AlterColumn<string>(
                name: "Lastname",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                defaultValue: "Unknown",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Firstname",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "Users",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "Firstname",
                table: "Users",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldDefaultValue: "Unknown");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
