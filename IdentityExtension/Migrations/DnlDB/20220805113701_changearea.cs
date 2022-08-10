using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityExtension.Migrations.DnlDB
{
    public partial class changearea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FuelBillTypes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    billType = table.Column<int>(nullable: false),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelBillTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "FuelBillAccounts",
                columns: table => new
                {
                    billAccId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    billType = table.Column<int>(nullable: false),
                    areaId = table.Column<int>(nullable: false),
                    baseId = table.Column<int>(nullable: false),
                    subUnitId = table.Column<int>(nullable: false),
                    accountNumber = table.Column<int>(nullable: false),
                    active = table.Column<bool>(nullable: false),
                    createdDate = table.Column<DateTime>(nullable: false),
                    userId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelBillAccounts", x => x.billAccId);
                    table.ForeignKey(
                        name: "FK_FuelBillAccounts_areas_areaId",
                        column: x => x.areaId,
                        principalTable: "areas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FuelBillAccounts_FuelBillTypes_billType",
                        column: x => x.billType,
                        principalTable: "FuelBillTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FuelBillDetails",
                columns: table => new
                {
                    fuelAccId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    billType = table.Column<int>(nullable: false),
                    year = table.Column<int>(nullable: false),
                    month = table.Column<string>(nullable: true),
                    lastMonth = table.Column<int>(nullable: false),
                    chargePerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    totalCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    departmentCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fixedCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    monthlyCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    billConfirm = table.Column<bool>(nullable: false),
                    createdDate = table.Column<DateTime>(nullable: false),
                    userId = table.Column<string>(nullable: true),
                    editDate = table.Column<DateTime>(nullable: false),
                    editUserId = table.Column<string>(nullable: true),
                    billConUserId = table.Column<string>(nullable: true),
                    billConDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelBillDetails", x => x.fuelAccId);
                    table.ForeignKey(
                        name: "FK_FuelBillDetails_FuelBillAccounts_billType",
                        column: x => x.billType,
                        principalTable: "FuelBillAccounts",
                        principalColumn: "billAccId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FuelBillSubDetails",
                columns: table => new
                {
                    fuelAccId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    billType = table.Column<int>(nullable: false),
                    year = table.Column<int>(nullable: false),
                    month = table.Column<string>(nullable: true),
                    lastMonth = table.Column<int>(nullable: false),
                    chargePerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    totalCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    sno = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fromDate = table.Column<DateTime>(nullable: false),
                    toDate = table.Column<DateTime>(nullable: false),
                    createdDate = table.Column<DateTime>(nullable: false),
                    userId = table.Column<string>(nullable: true),
                    editDate = table.Column<DateTime>(nullable: false),
                    editUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelBillSubDetails", x => x.fuelAccId);
                    table.ForeignKey(
                        name: "FK_FuelBillSubDetails_FuelBillAccounts_billType",
                        column: x => x.billType,
                        principalTable: "FuelBillAccounts",
                        principalColumn: "billAccId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FuelBillAccounts_areaId",
                table: "FuelBillAccounts",
                column: "areaId");

            migrationBuilder.CreateIndex(
                name: "IX_FuelBillAccounts_billType",
                table: "FuelBillAccounts",
                column: "billType");

            migrationBuilder.CreateIndex(
                name: "IX_FuelBillDetails_billType",
                table: "FuelBillDetails",
                column: "billType");

            migrationBuilder.CreateIndex(
                name: "IX_FuelBillSubDetails_billType",
                table: "FuelBillSubDetails",
                column: "billType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuelBillDetails");

            migrationBuilder.DropTable(
                name: "FuelBillSubDetails");

            migrationBuilder.DropTable(
                name: "FuelBillAccounts");

            migrationBuilder.DropTable(
                name: "FuelBillTypes");
        }
    }
}
