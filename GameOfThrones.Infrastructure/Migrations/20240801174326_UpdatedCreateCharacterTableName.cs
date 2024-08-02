using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameOfThrones.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedCreateCharacterTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Character",
                table: "Character");

            migrationBuilder.RenameTable(
                name: "Character",
                newName: "character");

            migrationBuilder.AddPrimaryKey(
                name: "PK_character",
                table: "character",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_character",
                table: "character");

            migrationBuilder.RenameTable(
                name: "character",
                newName: "Character");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Character",
                table: "Character",
                column: "Id");
        }
    }
}
