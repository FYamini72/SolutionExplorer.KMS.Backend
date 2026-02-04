using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolutionExplorer.KMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPersonnelTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personnels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Prefix = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    EducationalDegree = table.Column<int>(type: "int", nullable: false),
                    EducationalField = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FirstConfirmerUserId = table.Column<int>(type: "int", nullable: false),
                    SecondConfirmerUserId = table.Column<int>(type: "int", nullable: false),
                    SuccessorUserId = table.Column<int>(type: "int", nullable: true),
                    OrganizationalChart = table.Column<string>(type: "nvarchar(750)", maxLength: 750, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personnels_Users_FirstConfirmerUserId",
                        column: x => x.FirstConfirmerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personnels_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personnels_Users_SecondConfirmerUserId",
                        column: x => x.SecondConfirmerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personnels_Users_SuccessorUserId",
                        column: x => x.SuccessorUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personnels_FirstConfirmerUserId",
                table: "Personnels",
                column: "FirstConfirmerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnels_SecondConfirmerUserId",
                table: "Personnels",
                column: "SecondConfirmerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnels_SuccessorUserId",
                table: "Personnels",
                column: "SuccessorUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personnels");
        }
    }
}
