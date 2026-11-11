using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MYAcademy_PortfolioProject.Migrations
{
    /// <inheritdoc />
    public partial class mig6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_SkillCategory_SkillCategoryId",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SkillCategory",
                table: "SkillCategory");

            migrationBuilder.RenameTable(
                name: "SkillCategory",
                newName: "SkillCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SkillCategories",
                table: "SkillCategories",
                column: "SkillCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_SkillCategories_SkillCategoryId",
                table: "Skills",
                column: "SkillCategoryId",
                principalTable: "SkillCategories",
                principalColumn: "SkillCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_SkillCategories_SkillCategoryId",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SkillCategories",
                table: "SkillCategories");

            migrationBuilder.RenameTable(
                name: "SkillCategories",
                newName: "SkillCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SkillCategory",
                table: "SkillCategory",
                column: "SkillCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_SkillCategory_SkillCategoryId",
                table: "Skills",
                column: "SkillCategoryId",
                principalTable: "SkillCategory",
                principalColumn: "SkillCategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
