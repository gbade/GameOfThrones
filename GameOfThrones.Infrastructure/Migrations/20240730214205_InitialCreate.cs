using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GameOfThrones.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CharacterName = table.Column<string>(type: "text", nullable: true),
                    HouseName = table.Column<string>(type: "text", nullable: true),
                    Royal = table.Column<bool>(type: "boolean", nullable: true),
                    Parents = table.Column<List<string>>(type: "text[]", nullable: true),
                    Siblings = table.Column<List<string>>(type: "text[]", nullable: true),
                    KilledBy = table.Column<List<string>>(type: "text[]", nullable: true),
                    Killed = table.Column<List<string>>(type: "text[]", nullable: true),
                    Nickname = table.Column<string>(type: "text", nullable: true),
                    CharacterImageThumb = table.Column<string>(type: "text", nullable: true),
                    CharacterImageFull = table.Column<string>(type: "text", nullable: true),
                    CharacterLink = table.Column<string>(type: "text", nullable: true),
                    ActorName = table.Column<string>(type: "text", nullable: true),
                    ActorLink = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");
        }
    }
}
