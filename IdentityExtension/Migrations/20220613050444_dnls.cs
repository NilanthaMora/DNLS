using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityExtension.Migrations
{
    public partial class dnls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "equipment_Tables",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    equipmentCode = table.Column<int>(nullable: false),
                    equipment = table.Column<string>(nullable: false),
                    equipmentSellCode = table.Column<string>(nullable: true),
                    imageUrl = table.Column<string>(nullable: true),
                    equipmentGeneralInq = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipment_Tables", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "procurements",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    equipCode = table.Column<string>(nullable: true),
                    make = table.Column<string>(nullable: true),
                    model = table.Column<string>(nullable: true),
                    rlRef = table.Column<string>(nullable: true),
                    qtyOrdered = table.Column<string>(nullable: true),
                    qtyApproved = table.Column<string>(nullable: true),
                    lastPurchasePrice = table.Column<string>(nullable: true),
                    remarks = table.Column<string>(nullable: true),
                    userId = table.Column<string>(nullable: true),
                    cDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_procurements", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    productId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.productId);
                });

            migrationBuilder.CreateTable(
                name: "equipmentProcurements",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    item = table.Column<string>(nullable: true),
                    fileRef = table.Column<string>(nullable: true),
                    proDistribution = table.Column<string>(nullable: true),
                    procuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipmentProcurements", x => x.id);
                    table.ForeignKey(
                        name: "FK_equipmentProcurements_procurements_procuId",
                        column: x => x.procuId,
                        principalTable: "procurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_equipmentProcurements_procuId",
                table: "equipmentProcurements",
                column: "procuId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "equipment_Tables");

            migrationBuilder.DropTable(
                name: "equipmentProcurements");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "procurements");
        }
    }
}
