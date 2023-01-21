using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MatchNo = table.Column<int>(type: "INTEGER", nullable: false),
                    ManOfMatch = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TeamName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MatchInnings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InnningNo = table.Column<int>(type: "INTEGER", nullable: false),
                    TeamId = table.Column<int>(type: "INTEGER", nullable: false),
                    RunsScored = table.Column<int>(type: "INTEGER", nullable: false),
                    WicketsFallen = table.Column<int>(type: "INTEGER", nullable: false),
                    MatchId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchInnings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchInnings_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchTeams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TossWon = table.Column<bool>(type: "INTEGER", nullable: false),
                    MatchWon = table.Column<bool>(type: "INTEGER", nullable: false),
                    TeamId = table.Column<int>(type: "INTEGER", nullable: false),
                    MatchId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchTeams_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    TeamId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InningPlayerStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BattingPosition = table.Column<int>(type: "INTEGER", nullable: false),
                    RunsScored = table.Column<int>(type: "INTEGER", nullable: false),
                    BallsPlayed = table.Column<int>(type: "INTEGER", nullable: false),
                    CacthesTaken = table.Column<int>(type: "INTEGER", nullable: false),
                    WicketsTaken = table.Column<int>(type: "INTEGER", nullable: false),
                    OversBowled = table.Column<float>(type: "REAL", nullable: false),
                    MatchInningId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InningPlayerStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InningPlayerStats_MatchInnings_MatchInningId",
                        column: x => x.MatchInningId,
                        principalTable: "MatchInnings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InningPlayerStats_MatchInningId",
                table: "InningPlayerStats",
                column: "MatchInningId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchInnings_MatchId",
                table: "MatchInnings",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchTeams_MatchId",
                table: "MatchTeams",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchTeams_TeamId",
                table: "MatchTeams",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InningPlayerStats");

            migrationBuilder.DropTable(
                name: "MatchTeams");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "MatchInnings");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Matches");
        }
    }
}
