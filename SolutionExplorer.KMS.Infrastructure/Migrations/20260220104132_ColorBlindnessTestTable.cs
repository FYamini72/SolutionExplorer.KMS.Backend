using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolutionExplorer.KMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ColorBlindnessTestTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PersonnelNumber",
                table: "Personnels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PersonnelColorBlindnessTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonnelId = table.Column<int>(type: "int", nullable: false),
                    TestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RedColorDetection = table.Column<bool>(type: "bit", nullable: false),
                    BlueColorDetection = table.Column<bool>(type: "bit", nullable: false),
                    YellowColorDetection = table.Column<bool>(type: "bit", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    FirstConfirmerUserId = table.Column<int>(type: "int", nullable: false),
                    SecondConfirmerUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonnelColorBlindnessTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonnelColorBlindnessTests_Personnels_PersonnelId",
                        column: x => x.PersonnelId,
                        principalTable: "Personnels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonnelColorBlindnessTests_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PersonnelColorBlindnessTests_Users_FirstConfirmerUserId",
                        column: x => x.FirstConfirmerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonnelColorBlindnessTests_Users_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PersonnelColorBlindnessTests_Users_SecondConfirmerUserId",
                        column: x => x.SecondConfirmerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonnelColorBlindnessTests_CreatedByUserId",
                table: "PersonnelColorBlindnessTests",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonnelColorBlindnessTests_FirstConfirmerUserId",
                table: "PersonnelColorBlindnessTests",
                column: "FirstConfirmerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonnelColorBlindnessTests_ModifiedByUserId",
                table: "PersonnelColorBlindnessTests",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonnelColorBlindnessTests_PersonnelId",
                table: "PersonnelColorBlindnessTests",
                column: "PersonnelId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonnelColorBlindnessTests_SecondConfirmerUserId",
                table: "PersonnelColorBlindnessTests",
                column: "SecondConfirmerUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonnelColorBlindnessTests");

            migrationBuilder.DropColumn(
                name: "PersonnelNumber",
                table: "Personnels");
        }
    }
}
