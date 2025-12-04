using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolutionExplorer.KMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeQCTablesStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualityControlResults_QualityControls_QualityControlId",
                table: "QualityControlResults");

            migrationBuilder.DropColumn(
                name: "FinalResult",
                table: "QualityControls");

            migrationBuilder.DropColumn(
                name: "FinalResultNotes",
                table: "QualityControls");

            migrationBuilder.DropColumn(
                name: "PhysicalSpecification",
                table: "QualityControls");

            migrationBuilder.DropColumn(
                name: "ATCCControlOrganism",
                table: "QualityControlResults");

            migrationBuilder.DropColumn(
                name: "ExpectedResult",
                table: "QualityControlResults");

            migrationBuilder.DropColumn(
                name: "HaloDiameter",
                table: "QualityControlResults");

            migrationBuilder.DropColumn(
                name: "PoliGroup_A",
                table: "QualityControlResults");

            migrationBuilder.DropColumn(
                name: "PoliGroup_B",
                table: "QualityControlResults");

            migrationBuilder.DropColumn(
                name: "PoliGroup_C",
                table: "QualityControlResults");

            migrationBuilder.DropColumn(
                name: "PoliGroup_D",
                table: "QualityControlResults");

            migrationBuilder.DropColumn(
                name: "DefaultValue",
                table: "QualityControlBaseInfos");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "QualityControlBaseInfos");

            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "QualityControlBaseInfos");

            migrationBuilder.DropColumn(
                name: "ProductionDate",
                table: "QualityControlBaseInfos");

            migrationBuilder.DropColumn(
                name: "Series",
                table: "QualityControlBaseInfos");

            migrationBuilder.RenameColumn(
                name: "FinalCondition",
                table: "QualityControls",
                newName: "IsConfirmed");

            migrationBuilder.RenameColumn(
                name: "Result",
                table: "QualityControlResults",
                newName: "IsConfirmed");

            migrationBuilder.AlterColumn<int>(
                name: "QualityControlId",
                table: "QualityControlResults",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CorrectiveActions",
                table: "QualityControlResults",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QCBaseInfoExpectedResultId",
                table: "QualityControlResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "QCBaseInfoExpectedResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QualityControlBaseInfoId = table.Column<int>(type: "int", nullable: false),
                    ATCCControlOrganism = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpectedResult = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HaloDiameter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoliGroup_A = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoliGroup_B = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoliGroup_C = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoliGroup_D = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QCBaseInfoExpectedResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QCBaseInfoExpectedResults_QualityControlBaseInfos_QualityControlBaseInfoId",
                        column: x => x.QualityControlBaseInfoId,
                        principalTable: "QualityControlBaseInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QCBaseInfoExpectedResults_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QCBaseInfoExpectedResults_Users_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QCBaseInfoPhysicalSpecifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QualityControlBaseInfoId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QCBaseInfoPhysicalSpecifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QCBaseInfoPhysicalSpecifications_QualityControlBaseInfos_QualityControlBaseInfoId",
                        column: x => x.QualityControlBaseInfoId,
                        principalTable: "QualityControlBaseInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QCBaseInfoPhysicalSpecifications_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QCBaseInfoPhysicalSpecifications_Users_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PhysicalSpecifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QCBaseInfoPhysicalSpecificationId = table.Column<int>(type: "int", nullable: false),
                    QualityControlId = table.Column<int>(type: "int", nullable: false),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalSpecifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhysicalSpecifications_QCBaseInfoPhysicalSpecifications_QCBaseInfoPhysicalSpecificationId",
                        column: x => x.QCBaseInfoPhysicalSpecificationId,
                        principalTable: "QCBaseInfoPhysicalSpecifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhysicalSpecifications_QualityControls_QualityControlId",
                        column: x => x.QualityControlId,
                        principalTable: "QualityControls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhysicalSpecifications_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhysicalSpecifications_Users_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_QualityControlResults_QCBaseInfoExpectedResultId",
                table: "QualityControlResults",
                column: "QCBaseInfoExpectedResultId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalSpecifications_CreatedByUserId",
                table: "PhysicalSpecifications",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalSpecifications_ModifiedByUserId",
                table: "PhysicalSpecifications",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalSpecifications_QCBaseInfoPhysicalSpecificationId",
                table: "PhysicalSpecifications",
                column: "QCBaseInfoPhysicalSpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalSpecifications_QualityControlId",
                table: "PhysicalSpecifications",
                column: "QualityControlId");

            migrationBuilder.CreateIndex(
                name: "IX_QCBaseInfoExpectedResults_CreatedByUserId",
                table: "QCBaseInfoExpectedResults",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QCBaseInfoExpectedResults_ModifiedByUserId",
                table: "QCBaseInfoExpectedResults",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QCBaseInfoExpectedResults_QualityControlBaseInfoId",
                table: "QCBaseInfoExpectedResults",
                column: "QualityControlBaseInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_QCBaseInfoPhysicalSpecifications_CreatedByUserId",
                table: "QCBaseInfoPhysicalSpecifications",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QCBaseInfoPhysicalSpecifications_ModifiedByUserId",
                table: "QCBaseInfoPhysicalSpecifications",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QCBaseInfoPhysicalSpecifications_QualityControlBaseInfoId",
                table: "QCBaseInfoPhysicalSpecifications",
                column: "QualityControlBaseInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_QualityControlResults_QCBaseInfoExpectedResults_QCBaseInfoExpectedResultId",
                table: "QualityControlResults",
                column: "QCBaseInfoExpectedResultId",
                principalTable: "QCBaseInfoExpectedResults",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QualityControlResults_QualityControls_QualityControlId",
                table: "QualityControlResults",
                column: "QualityControlId",
                principalTable: "QualityControls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualityControlResults_QCBaseInfoExpectedResults_QCBaseInfoExpectedResultId",
                table: "QualityControlResults");

            migrationBuilder.DropForeignKey(
                name: "FK_QualityControlResults_QualityControls_QualityControlId",
                table: "QualityControlResults");

            migrationBuilder.DropTable(
                name: "PhysicalSpecifications");

            migrationBuilder.DropTable(
                name: "QCBaseInfoExpectedResults");

            migrationBuilder.DropTable(
                name: "QCBaseInfoPhysicalSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_QualityControlResults_QCBaseInfoExpectedResultId",
                table: "QualityControlResults");

            migrationBuilder.DropColumn(
                name: "CorrectiveActions",
                table: "QualityControlResults");

            migrationBuilder.DropColumn(
                name: "QCBaseInfoExpectedResultId",
                table: "QualityControlResults");

            migrationBuilder.RenameColumn(
                name: "IsConfirmed",
                table: "QualityControls",
                newName: "FinalCondition");

            migrationBuilder.RenameColumn(
                name: "IsConfirmed",
                table: "QualityControlResults",
                newName: "Result");

            migrationBuilder.AddColumn<string>(
                name: "FinalResult",
                table: "QualityControls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FinalResultNotes",
                table: "QualityControls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhysicalSpecification",
                table: "QualityControls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QualityControlId",
                table: "QualityControlResults",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ATCCControlOrganism",
                table: "QualityControlResults",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExpectedResult",
                table: "QualityControlResults",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "HaloDiameter",
                table: "QualityControlResults",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PoliGroup_A",
                table: "QualityControlResults",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PoliGroup_B",
                table: "QualityControlResults",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PoliGroup_C",
                table: "QualityControlResults",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PoliGroup_D",
                table: "QualityControlResults",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DefaultValue",
                table: "QualityControlBaseInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "QualityControlBaseInfos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "QualityControlBaseInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ProductionDate",
                table: "QualityControlBaseInfos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Series",
                table: "QualityControlBaseInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_QualityControlResults_QualityControls_QualityControlId",
                table: "QualityControlResults",
                column: "QualityControlId",
                principalTable: "QualityControls",
                principalColumn: "Id");
        }
    }
}
