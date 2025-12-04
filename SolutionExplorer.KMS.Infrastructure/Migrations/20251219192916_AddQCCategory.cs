using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolutionExplorer.KMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddQCCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "QualityControlBaseInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "QualityControlBaseInfos");
        }
    }
}
