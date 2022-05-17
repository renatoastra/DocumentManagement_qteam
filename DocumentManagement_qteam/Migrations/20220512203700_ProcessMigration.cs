using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentManagement.Migrations
{
    public partial class ProcessMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Process",
                table: "Document");

            migrationBuilder.AddColumn<int>(
                name: "ProcessId",
                table: "Document",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Document_ProcessId",
                table: "Document",
                column: "ProcessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Process_ProcessId",
                table: "Document",
                column: "ProcessId",
                principalTable: "Process",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_Process_ProcessId",
                table: "Document");

            migrationBuilder.DropIndex(
                name: "IX_Document_ProcessId",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "ProcessId",
                table: "Document");

            migrationBuilder.AddColumn<string>(
                name: "Process",
                table: "Document",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
