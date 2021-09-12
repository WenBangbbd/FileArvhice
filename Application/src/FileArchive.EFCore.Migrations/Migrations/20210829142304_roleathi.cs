using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FileArchive.EFCore.Migrations.Migrations
{
    public partial class roleathi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authority_Role_RoleId",
                table: "Authority");

            migrationBuilder.DropIndex(
                name: "IX_Authority_RoleId",
                table: "Authority");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Authority");

            migrationBuilder.CreateTable(
                name: "RoleAuthority",
                columns: table => new
                {
                    AuthorityId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifyDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleAuthority", x => new { x.RoleId, x.AuthorityId });
                    table.ForeignKey(
                        name: "FK_RoleAuthority_Authority_AuthorityId",
                        column: x => x.AuthorityId,
                        principalTable: "Authority",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleAuthority_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_RoleAuthority_AuthorityId",
                table: "RoleAuthority",
                column: "AuthorityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleAuthority");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Authority",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Authority_RoleId",
                table: "Authority",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authority_Role_RoleId",
                table: "Authority",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
