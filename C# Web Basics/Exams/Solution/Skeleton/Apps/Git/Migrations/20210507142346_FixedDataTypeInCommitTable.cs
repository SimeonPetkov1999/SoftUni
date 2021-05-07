using Microsoft.EntityFrameworkCore.Migrations;

namespace Git.Migrations
{
    public partial class FixedDataTypeInCommitTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commit_Users_CreatorId1",
                table: "Commit");

            migrationBuilder.DropForeignKey(
                name: "FK_Commit_Repositories_RepositoryId1",
                table: "Commit");

            migrationBuilder.DropIndex(
                name: "IX_Commit_CreatorId1",
                table: "Commit");

            migrationBuilder.DropIndex(
                name: "IX_Commit_RepositoryId1",
                table: "Commit");

            migrationBuilder.DropColumn(
                name: "CreatorId1",
                table: "Commit");

            migrationBuilder.DropColumn(
                name: "RepositoryId1",
                table: "Commit");

            migrationBuilder.AlterColumn<string>(
                name: "RepositoryId",
                table: "Commit",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "Commit",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Commit_CreatorId",
                table: "Commit",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Commit_RepositoryId",
                table: "Commit",
                column: "RepositoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commit_Users_CreatorId",
                table: "Commit",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Commit_Repositories_RepositoryId",
                table: "Commit",
                column: "RepositoryId",
                principalTable: "Repositories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commit_Users_CreatorId",
                table: "Commit");

            migrationBuilder.DropForeignKey(
                name: "FK_Commit_Repositories_RepositoryId",
                table: "Commit");

            migrationBuilder.DropIndex(
                name: "IX_Commit_CreatorId",
                table: "Commit");

            migrationBuilder.DropIndex(
                name: "IX_Commit_RepositoryId",
                table: "Commit");

            migrationBuilder.AlterColumn<int>(
                name: "RepositoryId",
                table: "Commit",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "Commit",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatorId1",
                table: "Commit",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RepositoryId1",
                table: "Commit",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Commit_CreatorId1",
                table: "Commit",
                column: "CreatorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Commit_RepositoryId1",
                table: "Commit",
                column: "RepositoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Commit_Users_CreatorId1",
                table: "Commit",
                column: "CreatorId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Commit_Repositories_RepositoryId1",
                table: "Commit",
                column: "RepositoryId1",
                principalTable: "Repositories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
