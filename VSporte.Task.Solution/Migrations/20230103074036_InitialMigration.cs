using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VSporte.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClubItems",
                columns: table => new
                {
                    ClubId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VsporteDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubItems", x => x.ClubId);
                });

            migrationBuilder.CreateTable(
                name: "PlayerItems",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VsporteDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerItems", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "GameEvents",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VsporteDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeOfEvent = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameEvents", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_GameEvents_ClubItems_ClubId",
                        column: x => x.ClubId,
                        principalTable: "ClubItems",
                        principalColumn: "ClubId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameEvents_PlayerItems_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "PlayerItems",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerClubItems",
                columns: table => new
                {
                    SystemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: false),
                    VsporteDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerClubItems", x => x.SystemId);
                    table.ForeignKey(
                        name: "FK_PlayerClubItems_ClubItems_ClubId",
                        column: x => x.ClubId,
                        principalTable: "ClubItems",
                        principalColumn: "ClubId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerClubItems_PlayerItems_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "PlayerItems",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameEvents_ClubId",
                table: "GameEvents",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_GameEvents_PlayerId",
                table: "GameEvents",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerClubItems_ClubId",
                table: "PlayerClubItems",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerClubItems_PlayerId",
                table: "PlayerClubItems",
                column: "PlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameEvents");

            migrationBuilder.DropTable(
                name: "PlayerClubItems");

            migrationBuilder.DropTable(
                name: "ClubItems");

            migrationBuilder.DropTable(
                name: "PlayerItems");
        }
    }
}
