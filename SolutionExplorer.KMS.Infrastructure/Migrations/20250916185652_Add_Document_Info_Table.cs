using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolutionExplorer.KMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_Document_Info_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LabName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EditNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EditDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmerOneName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmerOneSignImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmerTwoName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmerTwoSignImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentInfos_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocumentInfos_Users_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentInfos_CreatedByUserId",
                table: "DocumentInfos",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentInfos_ModifiedByUserId",
                table: "DocumentInfos",
                column: "ModifiedByUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentInfos");
        }
    }
}
