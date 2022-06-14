using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityExtension.Migrations
{
    public partial class dnls2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationId",
                table: "procurements",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UserRole = table.Column<string>(nullable: true),
                    MobileContact = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "spareProcurements",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    partNo = table.Column<string>(nullable: true),
                    sbRef = table.Column<string>(nullable: true),
                    currentStock = table.Column<string>(nullable: true),
                    firstRate = table.Column<string>(nullable: true),
                    secondRate = table.Column<string>(nullable: true),
                    thirdRate = table.Column<string>(nullable: true),
                    forthRate = table.Column<string>(nullable: true),
                    procuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spareProcurements", x => x.id);
                    table.ForeignKey(
                        name: "FK_spareProcurements_procurements_procuId",
                        column: x => x.procuId,
                        principalTable: "procurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_procurements_ApplicationId",
                table: "procurements",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_spareProcurements_procuId",
                table: "spareProcurements",
                column: "procuId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_procurements_ApplicationUser_ApplicationId",
                table: "procurements",
                column: "ApplicationId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_procurements_ApplicationUser_ApplicationId",
                table: "procurements");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropTable(
                name: "spareProcurements");

            migrationBuilder.DropIndex(
                name: "IX_procurements_ApplicationId",
                table: "procurements");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "procurements");
        }
    }
}
