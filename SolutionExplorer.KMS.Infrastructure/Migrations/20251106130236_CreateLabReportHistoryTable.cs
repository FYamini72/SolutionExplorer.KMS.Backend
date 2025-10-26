using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolutionExplorer.KMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateLabReportHistoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LabReportHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReporterUserId = table.Column<int>(type: "int", nullable: false),
                    ReceiverUserId = table.Column<int>(type: "int", nullable: true),
                    PatientName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AdmissionNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsCritical = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    ReporterComment = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    FirstConfirmerUserId = table.Column<int>(type: "int", nullable: false),
                    SecondConfirmerUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabReportHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabReportHistories_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LabReportHistories_Users_FirstConfirmerUserId",
                        column: x => x.FirstConfirmerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LabReportHistories_Users_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LabReportHistories_Users_ReceiverUserId",
                        column: x => x.ReceiverUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LabReportHistories_Users_ReporterUserId",
                        column: x => x.ReporterUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LabReportHistories_Users_SecondConfirmerUserId",
                        column: x => x.SecondConfirmerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabReportHistories_CreatedByUserId",
                table: "LabReportHistories",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LabReportHistories_FirstConfirmerUserId",
                table: "LabReportHistories",
                column: "FirstConfirmerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LabReportHistories_ModifiedByUserId",
                table: "LabReportHistories",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LabReportHistories_ReceiverUserId",
                table: "LabReportHistories",
                column: "ReceiverUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LabReportHistories_ReporterUserId",
                table: "LabReportHistories",
                column: "ReporterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LabReportHistories_SecondConfirmerUserId",
                table: "LabReportHistories",
                column: "SecondConfirmerUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabReportHistories");
        }
    }
}
