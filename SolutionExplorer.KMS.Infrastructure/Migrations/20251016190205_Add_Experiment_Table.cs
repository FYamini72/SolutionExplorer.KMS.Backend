using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolutionExplorer.KMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_Experiment_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Experiments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentifierId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    FirstConfirmerUserId = table.Column<int>(type: "int", nullable: false),
                    SecondConfirmerUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experiments_Identifiers_IdentifierId",
                        column: x => x.IdentifierId,
                        principalTable: "Identifiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Experiments_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Experiments_Users_FirstConfirmerUserId",
                        column: x => x.FirstConfirmerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Experiments_Users_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Experiments_Users_SecondConfirmerUserId",
                        column: x => x.SecondConfirmerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Experiments_CreatedByUserId",
                table: "Experiments",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiments_FirstConfirmerUserId",
                table: "Experiments",
                column: "FirstConfirmerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiments_IdentifierId",
                table: "Experiments",
                column: "IdentifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiments_ModifiedByUserId",
                table: "Experiments",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiments_SecondConfirmerUserId",
                table: "Experiments",
                column: "SecondConfirmerUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Experiments");
        }
    }
}
