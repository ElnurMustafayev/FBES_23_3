using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RelationsApp.Migrations
{
    /// <inheritdoc />
    public partial class AddPKforUserstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "MyPrimaryKey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");
        }
    }
}
