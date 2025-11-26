using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolutionExplorer.KMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIdentifierTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttachmentFileId",
                table: "Identifiers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Identifiers",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdentifierType",
                table: "Identifiers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FileCategory",
                table: "AttachmentFiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Identifiers_AttachmentFileId",
                table: "Identifiers",
                column: "AttachmentFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Identifiers_AttachmentFiles_AttachmentFileId",
                table: "Identifiers",
                column: "AttachmentFileId",
                principalTable: "AttachmentFiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Identifiers_AttachmentFiles_AttachmentFileId",
                table: "Identifiers");

            migrationBuilder.DropIndex(
                name: "IX_Identifiers_AttachmentFileId",
                table: "Identifiers");

            migrationBuilder.DropColumn(
                name: "AttachmentFileId",
                table: "Identifiers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Identifiers");

            migrationBuilder.DropColumn(
                name: "IdentifierType",
                table: "Identifiers");

            migrationBuilder.DropColumn(
                name: "FileCategory",
                table: "AttachmentFiles");
        }
    }
}
