using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityExtension.Migrations.DnlDB
{
    public partial class changeelectricitybilldetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ElectricityBillDetails_billType",
                table: "ElectricityBillDetails",
                column: "billType");

            migrationBuilder.AddForeignKey(
                name: "FK_ElectricityBillDetails_ElectricityBillTypes_billType",
                table: "ElectricityBillDetails",
                column: "billType",
                principalTable: "ElectricityBillTypes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElectricityBillDetails_ElectricityBillTypes_billType",
                table: "ElectricityBillDetails");

            migrationBuilder.DropIndex(
                name: "IX_ElectricityBillDetails_billType",
                table: "ElectricityBillDetails");
        }
    }
}
