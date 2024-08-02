using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameOfThrones.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedColumnsToLowerCase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Siblings",
                table: "character",
                newName: "siblings");

            migrationBuilder.RenameColumn(
                name: "Royal",
                table: "character",
                newName: "royal");

            migrationBuilder.RenameColumn(
                name: "Parents",
                table: "character",
                newName: "parents");

            migrationBuilder.RenameColumn(
                name: "Nickname",
                table: "character",
                newName: "nickname");

            migrationBuilder.RenameColumn(
                name: "KilledBy",
                table: "character",
                newName: "killedby");

            migrationBuilder.RenameColumn(
                name: "Killed",
                table: "character",
                newName: "killed");

            migrationBuilder.RenameColumn(
                name: "HouseName",
                table: "character",
                newName: "housename");

            migrationBuilder.RenameColumn(
                name: "CharacterName",
                table: "character",
                newName: "charactername");

            migrationBuilder.RenameColumn(
                name: "CharacterLink",
                table: "character",
                newName: "characterlink");

            migrationBuilder.RenameColumn(
                name: "CharacterImageThumb",
                table: "character",
                newName: "characterimagethumb");

            migrationBuilder.RenameColumn(
                name: "CharacterImageFull",
                table: "character",
                newName: "characterimagefull");

            migrationBuilder.RenameColumn(
                name: "ActorName",
                table: "character",
                newName: "actorname");

            migrationBuilder.RenameColumn(
                name: "ActorLink",
                table: "character",
                newName: "actorlink");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "character",
                newName: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "siblings",
                table: "character",
                newName: "Siblings");

            migrationBuilder.RenameColumn(
                name: "royal",
                table: "character",
                newName: "Royal");

            migrationBuilder.RenameColumn(
                name: "parents",
                table: "character",
                newName: "Parents");

            migrationBuilder.RenameColumn(
                name: "nickname",
                table: "character",
                newName: "Nickname");

            migrationBuilder.RenameColumn(
                name: "killedby",
                table: "character",
                newName: "KilledBy");

            migrationBuilder.RenameColumn(
                name: "killed",
                table: "character",
                newName: "Killed");

            migrationBuilder.RenameColumn(
                name: "housename",
                table: "character",
                newName: "HouseName");

            migrationBuilder.RenameColumn(
                name: "charactername",
                table: "character",
                newName: "CharacterName");

            migrationBuilder.RenameColumn(
                name: "characterlink",
                table: "character",
                newName: "CharacterLink");

            migrationBuilder.RenameColumn(
                name: "characterimagethumb",
                table: "character",
                newName: "CharacterImageThumb");

            migrationBuilder.RenameColumn(
                name: "characterimagefull",
                table: "character",
                newName: "CharacterImageFull");

            migrationBuilder.RenameColumn(
                name: "actorname",
                table: "character",
                newName: "ActorName");

            migrationBuilder.RenameColumn(
                name: "actorlink",
                table: "character",
                newName: "ActorLink");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "character",
                newName: "Id");
        }
    }
}
