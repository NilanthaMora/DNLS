using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityExtension.Migrations.DnlDB
{
    public partial class addelectricitybill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ElectricityBillDetailBulks",
                columns: table => new
                {
                    eleAccId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    billType = table.Column<int>(nullable: false),
                    year = table.Column<int>(nullable: false),
                    month = table.Column<string>(nullable: true),
                    peakLastMonth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    peakCurrentMonth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    peakUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    peakChargePerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    dayLastMonth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    dayCurrentMonth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    dayUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    dayChargePerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    offLastMonth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    offCurrentMonth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    offUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    offChargePerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    kvaUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    kvaChargePerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    departmentCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fixedCharges = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    monthlyCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    billConfirm = table.Column<bool>(nullable: false),
                    createdDate = table.Column<DateTime>(nullable: false),
                    userId = table.Column<string>(nullable: true),
                    editDate = table.Column<DateTime>(nullable: false),
                    editUserId = table.Column<string>(nullable: true),
                    billConUserId = table.Column<string>(nullable: true),
                    billConDate = table.Column<DateTime>(nullable: false),
                    adfRefer = table.Column<string>(nullable: true),
                    adfDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricityBillDetailBulks", x => x.eleAccId);
                });

            migrationBuilder.CreateTable(
                name: "ElectricityBillDetailDomestics",
                columns: table => new
                {
                    eleAccId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    billType = table.Column<int>(nullable: false),
                    year = table.Column<int>(nullable: false),
                    month = table.Column<string>(nullable: true),
                    totalUnits = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    unit_0_30 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    unitPrice_0_30 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fixCharge_0_30 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    unit_31_60 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    unitPrice_31_60 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fixCharge_31_60 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    unit_0_60 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    unitPrice_0_60 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fixCharge_0_60 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    unit_61_90 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    unitPrice_61_90 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fixCharge_61_90 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    unit_91_120 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    unitPrice_91_120 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fixCharge_91_120 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    unit_121_180 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    unitPrice_121_180 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fixCharge_121_180 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    unit_180 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    unitPrice_180 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fixCharge_180 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    monthlyCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    billConfirm = table.Column<bool>(nullable: false),
                    createdDate = table.Column<DateTime>(nullable: false),
                    userId = table.Column<string>(nullable: true),
                    editDate = table.Column<DateTime>(nullable: false),
                    editUserId = table.Column<string>(nullable: true),
                    billConUserId = table.Column<string>(nullable: true),
                    billConDate = table.Column<DateTime>(nullable: false),
                    adfRefer = table.Column<string>(nullable: true),
                    adfDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricityBillDetailDomestics", x => x.eleAccId);
                });

            migrationBuilder.CreateTable(
                name: "ElectricityBillDetails",
                columns: table => new
                {
                    eleAccId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    billType = table.Column<int>(nullable: false),
                    year = table.Column<int>(nullable: false),
                    month = table.Column<string>(nullable: true),
                    lastMonth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    currentMonth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    unit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    chargePerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    departmentCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fixedCharges = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    monthlyCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    billConfirm = table.Column<bool>(nullable: false),
                    createdDate = table.Column<DateTime>(nullable: false),
                    userId = table.Column<string>(nullable: true),
                    editDate = table.Column<DateTime>(nullable: false),
                    editUserId = table.Column<string>(nullable: true),
                    billConUserId = table.Column<string>(nullable: true),
                    billConDate = table.Column<DateTime>(nullable: false),
                    adfRefer = table.Column<string>(nullable: true),
                    adfDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricityBillDetails", x => x.eleAccId);
                });

            migrationBuilder.CreateTable(
                name: "ElectricityBillTypes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    billType = table.Column<int>(nullable: false),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricityBillTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ElectricityAccountBills",
                columns: table => new
                {
                    billAccId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    billType = table.Column<int>(nullable: false),
                    areaId = table.Column<int>(nullable: false),
                    baseId = table.Column<int>(nullable: false),
                    subUnitId = table.Column<int>(nullable: false),
                    accountNumber = table.Column<int>(nullable: false),
                    capacity = table.Column<string>(nullable: true),
                    active = table.Column<bool>(nullable: false),
                    createdDate = table.Column<DateTime>(nullable: false),
                    userId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricityAccountBills", x => x.billAccId);
                    table.ForeignKey(
                        name: "FK_ElectricityAccountBills_areas_areaId",
                        column: x => x.areaId,
                        principalTable: "areas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElectricityAccountBills_ElectricityBillTypes_billType",
                        column: x => x.billType,
                        principalTable: "ElectricityBillTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElectricityAccountBills_areaId",
                table: "ElectricityAccountBills",
                column: "areaId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricityAccountBills_billType",
                table: "ElectricityAccountBills",
                column: "billType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElectricityAccountBills");

            migrationBuilder.DropTable(
                name: "ElectricityBillDetailBulks");

            migrationBuilder.DropTable(
                name: "ElectricityBillDetailDomestics");

            migrationBuilder.DropTable(
                name: "ElectricityBillDetails");

            migrationBuilder.DropTable(
                name: "ElectricityBillTypes");
        }
    }
}
