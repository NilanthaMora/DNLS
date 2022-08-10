using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityExtension.Migrations.DnlDB
{
    public partial class updatednl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ammunitions",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ammunitions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "areas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    code = table.Column<int>(nullable: false),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_areas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "canonTypes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_canonTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "equipment_Tables",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    equipmentCode = table.Column<int>(nullable: false),
                    equipment = table.Column<string>(nullable: false),
                    varName = table.Column<string>(nullable: false),
                    equipmentSellCode = table.Column<string>(nullable: true),
                    imageUrl = table.Column<string>(nullable: true),
                    equipmentGeneralInq = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipment_Tables", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EquipProcuView",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    equipCode = table.Column<int>(nullable: false),
                    make = table.Column<string>(nullable: true),
                    model = table.Column<string>(nullable: true),
                    rlRef = table.Column<string>(nullable: true),
                    qtyOrdered = table.Column<string>(nullable: true),
                    qtyApproved = table.Column<string>(nullable: true),
                    lastPurchasePrice = table.Column<string>(nullable: true),
                    remarks = table.Column<string>(nullable: true),
                    userId = table.Column<string>(nullable: true),
                    cDate = table.Column<DateTime>(nullable: false),
                    item = table.Column<string>(nullable: true),
                    fileRef = table.Column<string>(nullable: true),
                    proDistribution = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipProcuView", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Makes",
                columns: table => new
                {
                    makeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makes", x => x.makeId);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    modelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.modelId);
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
                name: "ShipType",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    code = table.Column<int>(nullable: false),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SpareProcuView",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    equipCode = table.Column<int>(nullable: false),
                    make = table.Column<string>(nullable: true),
                    model = table.Column<string>(nullable: true),
                    rlRef = table.Column<string>(nullable: true),
                    qtyOrdered = table.Column<string>(nullable: true),
                    qtyApproved = table.Column<string>(nullable: true),
                    lastPurchasePrice = table.Column<string>(nullable: true),
                    remarks = table.Column<string>(nullable: true),
                    userId = table.Column<string>(nullable: true),
                    cDate = table.Column<DateTime>(nullable: false),
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
                    table.PrimaryKey("PK_SpareProcuView", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "procurements",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    equipCode = table.Column<int>(nullable: false),
                    make = table.Column<string>(nullable: true),
                    model = table.Column<string>(nullable: true),
                    rlRef = table.Column<string>(nullable: true),
                    qtyOrdered = table.Column<string>(nullable: true),
                    qtyApproved = table.Column<string>(nullable: true),
                    lastPurchasePrice = table.Column<string>(nullable: true),
                    remarks = table.Column<string>(nullable: true),
                    cDate = table.Column<DateTime>(nullable: false),
                    userId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_procurements", x => x.id);
                    table.ForeignKey(
                        name: "FK_procurements_equipment_Tables_equipCode",
                        column: x => x.equipCode,
                        principalTable: "equipment_Tables",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MakeModels",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    makeId = table.Column<int>(nullable: false),
                    modelId = table.Column<int>(nullable: false),
                    system = table.Column<string>(nullable: true),
                    eqTId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MakeModels", x => new { x.makeId, x.modelId });
                    table.UniqueConstraint("AK_MakeModels_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_MakeModels_equipment_Tables_eqTId",
                        column: x => x.eqTId,
                        principalTable: "equipment_Tables",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MakeModels_Makes_makeId",
                        column: x => x.makeId,
                        principalTable: "Makes",
                        principalColumn: "makeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MakeModels_Models_modelId",
                        column: x => x.modelId,
                        principalTable: "Models",
                        principalColumn: "modelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bases",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    code = table.Column<int>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    remCd = table.Column<string>(nullable: true),
                    payBase = table.Column<string>(nullable: true),
                    areaId = table.Column<int>(nullable: false),
                    baseType = table.Column<int>(nullable: false),
                    shipTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bases", x => x.id);
                    table.ForeignKey(
                        name: "FK_bases_areas_areaId",
                        column: x => x.areaId,
                        principalTable: "areas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bases_ShipType_shipTypeId",
                        column: x => x.shipTypeId,
                        principalTable: "ShipType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "equipments",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    srNo = table.Column<string>(nullable: false),
                    make = table.Column<string>(nullable: true),
                    model = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    eqBase = table.Column<int>(nullable: false),
                    remarks = table.Column<string>(nullable: true),
                    userId = table.Column<string>(nullable: true),
                    cDate = table.Column<DateTime>(nullable: true),
                    action = table.Column<string>(nullable: true),
                    g47Remarks = table.Column<string>(nullable: true),
                    g47Date = table.Column<DateTime>(nullable: true),
                    del = table.Column<string>(nullable: true),
                    delDate = table.Column<DateTime>(nullable: true),
                    eqTId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipments", x => x.id);
                    table.ForeignKey(
                        name: "FK_equipments_bases_eqBase",
                        column: x => x.eqBase,
                        principalTable: "bases",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_equipments_equipment_Tables_eqTId",
                        column: x => x.eqTId,
                        principalTable: "equipment_Tables",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subUnits",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    subUnitCode = table.Column<int>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    baseId = table.Column<int>(nullable: false),
                    type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subUnits", x => x.id);
                    table.ForeignKey(
                        name: "FK_subUnits_bases_baseId",
                        column: x => x.baseId,
                        principalTable: "bases",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ais",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    eqId = table.Column<int>(nullable: false),
                    location = table.Column<string>(nullable: true),
                    freqBand = table.Column<string>(nullable: true),
                    powerOp = table.Column<string>(nullable: true),
                    security = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    maxDetectRange = table.Column<string>(nullable: true),
                    antennaHeight = table.Column<string>(nullable: true),
                    dateInstalled = table.Column<DateTime>(nullable: true),
                    dateModified = table.Column<DateTime>(nullable: true),
                    pfileNum = table.Column<string>(nullable: true),
                    pfileDate = table.Column<DateTime>(nullable: true),
                    price = table.Column<string>(nullable: true),
                    weDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ais", x => x.id);
                    table.ForeignKey(
                        name: "FK_ais_equipments_eqId",
                        column: x => x.eqId,
                        principalTable: "equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "anemometers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    eqId = table.Column<int>(nullable: false),
                    location = table.Column<string>(nullable: true),
                    outputPower = table.Column<string>(nullable: true),
                    dateInstalled = table.Column<DateTime>(nullable: true),
                    dateModified = table.Column<DateTime>(nullable: true),
                    pfileNum = table.Column<string>(nullable: true),
                    pfileDate = table.Column<DateTime>(nullable: true),
                    price = table.Column<string>(nullable: true),
                    weDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_anemometers", x => x.id);
                    table.ForeignKey(
                        name: "FK_anemometers_equipments_eqId",
                        column: x => x.eqId,
                        principalTable: "equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cCTVs",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    eqId = table.Column<int>(nullable: false),
                    location = table.Column<string>(nullable: true),
                    dateInstalled = table.Column<DateTime>(nullable: true),
                    dateModified = table.Column<DateTime>(nullable: true),
                    systemType = table.Column<string>(nullable: true),
                    systemId = table.Column<string>(nullable: true),
                    channels = table.Column<string>(nullable: true),
                    noOfCameras = table.Column<string>(nullable: true),
                    noOfDisplays = table.Column<string>(nullable: true),
                    noOfHdd = table.Column<string>(nullable: true),
                    typeOfCameras = table.Column<string>(nullable: true),
                    typeOfDisplays = table.Column<string>(nullable: true),
                    typeOfHdd = table.Column<string>(nullable: true),
                    typeOfPeriod = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cCTVs", x => x.id);
                    table.ForeignKey(
                        name: "FK_cCTVs_equipments_eqId",
                        column: x => x.eqId,
                        principalTable: "equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "communications",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    eqId = table.Column<int>(nullable: false),
                    freqBand = table.Column<string>(nullable: true),
                    powerOp = table.Column<string>(nullable: true),
                    location = table.Column<string>(nullable: true),
                    security = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    dateInstalled = table.Column<DateTime>(nullable: true),
                    dateModified = table.Column<DateTime>(nullable: true),
                    pfileNum = table.Column<string>(nullable: true),
                    pfileDate = table.Column<DateTime>(nullable: true),
                    price = table.Column<string>(nullable: true),
                    weDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_communications", x => x.id);
                    table.ForeignKey(
                        name: "FK_communications_equipments_eqId",
                        column: x => x.eqId,
                        principalTable: "equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dVRs",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    eqId = table.Column<int>(nullable: false),
                    location = table.Column<string>(nullable: true),
                    dvrSubmitType = table.Column<string>(nullable: true),
                    dvrSubmitSrno = table.Column<string>(nullable: true),
                    dvrSubmitState = table.Column<string>(nullable: true),
                    dvrSubmitMake = table.Column<string>(nullable: true),
                    dvrSubmitModel = table.Column<string>(nullable: true),
                    dateInstalled = table.Column<DateTime>(nullable: true),
                    dateModified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dVRs", x => x.id);
                    table.ForeignKey(
                        name: "FK_dVRs_equipments_eqId",
                        column: x => x.eqId,
                        principalTable: "equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "eCDIs",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    eqId = table.Column<int>(nullable: false),
                    location = table.Column<string>(nullable: true),
                    dateInstalled = table.Column<DateTime>(nullable: true),
                    pfileNum = table.Column<string>(nullable: true),
                    pfileDate = table.Column<DateTime>(nullable: true),
                    price = table.Column<string>(nullable: true),
                    weDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eCDIs", x => x.id);
                    table.ForeignKey(
                        name: "FK_eCDIs_equipments_eqId",
                        column: x => x.eqId,
                        principalTable: "equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "engines",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    equipId = table.Column<int>(nullable: false),
                    powerRating = table.Column<string>(nullable: true),
                    dateInstalled = table.Column<DateTime>(nullable: true),
                    dateModified = table.Column<DateTime>(nullable: true),
                    proFileDate = table.Column<DateTime>(nullable: true),
                    warrantyDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_engines", x => x.id);
                    table.ForeignKey(
                        name: "FK_engines_equipments_equipId",
                        column: x => x.equipId,
                        principalTable: "equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "eODs",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    eqId = table.Column<int>(nullable: false),
                    country = table.Column<string>(nullable: true),
                    dateInstalled = table.Column<DateTime>(nullable: true),
                    dateModified = table.Column<DateTime>(nullable: true),
                    pfileNum = table.Column<string>(nullable: true),
                    pfileDate = table.Column<DateTime>(nullable: true),
                    price = table.Column<string>(nullable: true),
                    pulseCount = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eODs", x => x.id);
                    table.ForeignKey(
                        name: "FK_eODs_equipments_eqId",
                        column: x => x.eqId,
                        principalTable: "equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "epirbs",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    eqId = table.Column<int>(nullable: false),
                    location = table.Column<string>(nullable: true),
                    mmsiReg = table.Column<string>(nullable: true),
                    hruRepDate = table.Column<DateTime>(nullable: true),
                    batteryExpDate = table.Column<DateTime>(nullable: true),
                    dateInstalled = table.Column<DateTime>(nullable: true),
                    dateModified = table.Column<DateTime>(nullable: true),
                    pfileNum = table.Column<string>(nullable: true),
                    pfileDate = table.Column<DateTime>(nullable: true),
                    price = table.Column<string>(nullable: true),
                    weDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_epirbs", x => x.id);
                    table.ForeignKey(
                        name: "FK_epirbs_equipments_eqId",
                        column: x => x.eqId,
                        principalTable: "equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "generators",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    eqId = table.Column<int>(nullable: false),
                    mountedAt = table.Column<string>(nullable: true),
                    kva = table.Column<string>(nullable: true),
                    voltage = table.Column<string>(nullable: true),
                    phase = table.Column<string>(nullable: true),
                    frequancy = table.Column<string>(nullable: true),
                    alternatorModel = table.Column<string>(nullable: true),
                    alternatorMake = table.Column<string>(nullable: true),
                    alternatorSrno = table.Column<string>(nullable: true),
                    primemoverModel = table.Column<string>(nullable: true),
                    primemoverMake = table.Column<string>(nullable: true),
                    primemoverSrno = table.Column<string>(nullable: true),
                    mrh = table.Column<string>(nullable: true),
                    totalRunHours = table.Column<string>(nullable: true),
                    fullLoad = table.Column<string>(nullable: true),
                    maxLoad = table.Column<string>(nullable: true),
                    presentage = table.Column<string>(nullable: true),
                    ledgerPageNo = table.Column<string>(nullable: true),
                    mode = table.Column<string>(nullable: true),
                    dateModified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generators", x => x.id);
                    table.ForeignKey(
                        name: "FK_generators_equipments_eqId",
                        column: x => x.eqId,
                        principalTable: "equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "gps",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    eqId = table.Column<int>(nullable: false),
                    location = table.Column<string>(nullable: true),
                    dateInstalled = table.Column<DateTime>(nullable: true),
                    dateModified = table.Column<DateTime>(nullable: true),
                    pfileNum = table.Column<string>(nullable: true),
                    pfileDate = table.Column<DateTime>(nullable: true),
                    price = table.Column<string>(nullable: true),
                    weDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gps", x => x.id);
                    table.ForeignKey(
                        name: "FK_gps_equipments_eqId",
                        column: x => x.eqId,
                        principalTable: "equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "guncoms",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    eqId = table.Column<int>(nullable: false),
                    location = table.Column<string>(nullable: true),
                    dateInstalled = table.Column<DateTime>(nullable: true),
                    dateModified = table.Column<DateTime>(nullable: true),
                    pfileNum = table.Column<string>(nullable: true),
                    pfileDate = table.Column<DateTime>(nullable: true),
                    price = table.Column<string>(nullable: true),
                    weDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guncoms", x => x.id);
                    table.ForeignKey(
                        name: "FK_guncoms_equipments_eqId",
                        column: x => x.eqId,
                        principalTable: "equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "gyros",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    eqId = table.Column<int>(nullable: false),
                    location = table.Column<string>(nullable: true),
                    interfaceUsed = table.Column<string>(nullable: true),
                    dateInstalled = table.Column<DateTime>(nullable: true),
                    dateModified = table.Column<DateTime>(nullable: true),
                    pfileNum = table.Column<string>(nullable: true),
                    pfileDate = table.Column<DateTime>(nullable: true),
                    price = table.Column<string>(nullable: true),
                    weDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gyros", x => x.id);
                    table.ForeignKey(
                        name: "FK_gyros_equipments_eqId",
                        column: x => x.eqId,
                        principalTable: "equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "integratedHeadingSensors",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    eqId = table.Column<int>(nullable: false),
                    location = table.Column<string>(nullable: true),
                    interfaceUsed = table.Column<string>(nullable: true),
                    dateInstalled = table.Column<DateTime>(nullable: true),
                    dateModified = table.Column<DateTime>(nullable: true),
                    pfileNum = table.Column<string>(nullable: true),
                    pfileDate = table.Column<DateTime>(nullable: true),
                    price = table.Column<string>(nullable: true),
                    weDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_integratedHeadingSensors", x => x.id);
                    table.ForeignKey(
                        name: "FK_integratedHeadingSensors_equipments_eqId",
                        column: x => x.eqId,
                        principalTable: "equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "miniSats",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    eqId = table.Column<int>(nullable: false),
                    location = table.Column<string>(nullable: true),
                    dateInstalled = table.Column<DateTime>(nullable: true),
                    pfileNum = table.Column<string>(nullable: true),
                    pfileDate = table.Column<DateTime>(nullable: true),
                    price = table.Column<string>(nullable: true),
                    weDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_miniSats", x => x.id);
                    table.ForeignKey(
                        name: "FK_miniSats_equipments_eqId",
                        column: x => x.eqId,
                        principalTable: "equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "navtexs",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    eqId = table.Column<int>(nullable: false),
                    location = table.Column<string>(nullable: true),
                    dateInstalled = table.Column<DateTime>(nullable: true),
                    pfileNum = table.Column<string>(nullable: true),
                    pfileDate = table.Column<DateTime>(nullable: true),
                    price = table.Column<string>(nullable: true),
                    weDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_navtexs", x => x.id);
                    table.ForeignKey(
                        name: "FK_navtexs_equipments_eqId",
                        column: x => x.eqId,
                        principalTable: "equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "radars",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    eqId = table.Column<int>(nullable: false),
                    power = table.Column<string>(nullable: true),
                    location = table.Column<string>(nullable: true),
                    voltage = table.Column<string>(nullable: true),
                    scannerLength = table.Column<string>(nullable: true),
                    supply = table.Column<string>(nullable: true),
                    dateInstalled = table.Column<DateTime>(nullable: true),
                    dateModified = table.Column<DateTime>(nullable: true),
                    dingyRange = table.Column<string>(nullable: true),
                    trawlerRange = table.Column<string>(nullable: true),
                    ipcRange = table.Column<string>(nullable: true),
                    facRange = table.Column<string>(nullable: true),
                    fgbRange = table.Column<string>(nullable: true),
                    runningHours = table.Column<string>(nullable: true),
                    pfileNum = table.Column<string>(nullable: true),
                    pfileDate = table.Column<DateTime>(nullable: true),
                    price = table.Column<string>(nullable: true),
                    weDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_radars", x => x.id);
                    table.ForeignKey(
                        name: "FK_radars_equipments_eqId",
                        column: x => x.eqId,
                        principalTable: "equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sarts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    eqId = table.Column<int>(nullable: false),
                    location = table.Column<string>(nullable: true),
                    outputPower = table.Column<string>(nullable: true),
                    dateInstalled = table.Column<DateTime>(nullable: true),
                    dateModified = table.Column<DateTime>(nullable: true),
                    pfileNum = table.Column<string>(nullable: true),
                    pfileDate = table.Column<DateTime>(nullable: true),
                    price = table.Column<string>(nullable: true),
                    weDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sarts", x => x.id);
                    table.ForeignKey(
                        name: "FK_sarts_equipments_eqId",
                        column: x => x.eqId,
                        principalTable: "equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "satCompasses",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    eqId = table.Column<int>(nullable: false),
                    location = table.Column<string>(nullable: true),
                    dateInstalled = table.Column<DateTime>(nullable: true),
                    dateModified = table.Column<DateTime>(nullable: true),
                    pfileNum = table.Column<string>(nullable: true),
                    pfileDate = table.Column<DateTime>(nullable: true),
                    price = table.Column<string>(nullable: true),
                    weDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_satCompasses", x => x.id);
                    table.ForeignKey(
                        name: "FK_satCompasses_equipments_eqId",
                        column: x => x.eqId,
                        principalTable: "equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "satPhones",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    eqId = table.Column<int>(nullable: false),
                    location = table.Column<string>(nullable: true),
                    inSNo = table.Column<string>(nullable: true),
                    antennaSrno = table.Column<string>(nullable: true),
                    receiverSrno = table.Column<string>(nullable: true),
                    voice = table.Column<string>(nullable: true),
                    fax = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    dataLimit = table.Column<string>(nullable: true),
                    imeNo = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    dateInstalled = table.Column<DateTime>(nullable: true),
                    dateModified = table.Column<DateTime>(nullable: true),
                    pfileNum = table.Column<string>(nullable: true),
                    pfileDate = table.Column<DateTime>(nullable: true),
                    price = table.Column<string>(nullable: true),
                    weDate = table.Column<DateTime>(nullable: true),
                    expireDateBattery = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_satPhones", x => x.id);
                    table.ForeignKey(
                        name: "FK_satPhones_equipments_eqId",
                        column: x => x.eqId,
                        principalTable: "equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sonars",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    eqId = table.Column<int>(nullable: false),
                    location = table.Column<string>(nullable: true),
                    typeOfTransducer = table.Column<string>(nullable: true),
                    dateInstalled = table.Column<DateTime>(nullable: true),
                    dateModified = table.Column<DateTime>(nullable: true),
                    pfileNum = table.Column<string>(nullable: true),
                    pfileDate = table.Column<DateTime>(nullable: true),
                    price = table.Column<string>(nullable: true),
                    weDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sonars", x => x.id);
                    table.ForeignKey(
                        name: "FK_sonars_equipments_eqId",
                        column: x => x.eqId,
                        principalTable: "equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "speedLogs",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    eqId = table.Column<int>(nullable: false),
                    location = table.Column<string>(nullable: true),
                    outputPower = table.Column<string>(nullable: true),
                    dateInstalled = table.Column<DateTime>(nullable: true),
                    dateModified = table.Column<DateTime>(nullable: true),
                    pfileNum = table.Column<string>(nullable: true),
                    pfileDate = table.Column<DateTime>(nullable: true),
                    price = table.Column<string>(nullable: true),
                    weDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_speedLogs", x => x.id);
                    table.ForeignKey(
                        name: "FK_speedLogs_equipments_eqId",
                        column: x => x.eqId,
                        principalTable: "equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "weapons",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    eqId = table.Column<int>(nullable: false),
                    location = table.Column<string>(nullable: true),
                    outputPower = table.Column<string>(nullable: true),
                    dateInstalled = table.Column<DateTime>(nullable: true),
                    dateModified = table.Column<DateTime>(nullable: true),
                    pfileNum = table.Column<string>(nullable: true),
                    pfileDate = table.Column<DateTime>(nullable: true),
                    price = table.Column<string>(nullable: true),
                    weDate = table.Column<DateTime>(nullable: true),
                    Ammunitionid = table.Column<int>(nullable: true),
                    Countryid = table.Column<int>(nullable: true),
                    CanonTypeid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weapons", x => x.id);
                    table.ForeignKey(
                        name: "FK_weapons_ammunitions_Ammunitionid",
                        column: x => x.Ammunitionid,
                        principalTable: "ammunitions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_weapons_canonTypes_CanonTypeid",
                        column: x => x.CanonTypeid,
                        principalTable: "canonTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_weapons_countries_Countryid",
                        column: x => x.Countryid,
                        principalTable: "countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_weapons_equipments_eqId",
                        column: x => x.eqId,
                        principalTable: "equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "xenonS",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    eqId = table.Column<int>(nullable: false),
                    location = table.Column<string>(nullable: true),
                    outputPower = table.Column<string>(nullable: true),
                    dateInstalled = table.Column<DateTime>(nullable: true),
                    dateModified = table.Column<DateTime>(nullable: true),
                    pfileNum = table.Column<string>(nullable: true),
                    pfileDate = table.Column<DateTime>(nullable: true),
                    price = table.Column<string>(nullable: true),
                    weDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_xenonS", x => x.id);
                    table.ForeignKey(
                        name: "FK_xenonS_equipments_eqId",
                        column: x => x.eqId,
                        principalTable: "equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ais_eqId",
                table: "ais",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_anemometers_eqId",
                table: "anemometers",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_bases_areaId",
                table: "bases",
                column: "areaId");

            migrationBuilder.CreateIndex(
                name: "IX_bases_shipTypeId",
                table: "bases",
                column: "shipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_cCTVs_eqId",
                table: "cCTVs",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_communications_eqId",
                table: "communications",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_dVRs_eqId",
                table: "dVRs",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_eCDIs_eqId",
                table: "eCDIs",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_engines_equipId",
                table: "engines",
                column: "equipId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_eODs_eqId",
                table: "eODs",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_epirbs_eqId",
                table: "epirbs",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_equipmentProcurements_procuId",
                table: "equipmentProcurements",
                column: "procuId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_equipments_eqBase",
                table: "equipments",
                column: "eqBase");

            migrationBuilder.CreateIndex(
                name: "IX_equipments_eqTId",
                table: "equipments",
                column: "eqTId");

            migrationBuilder.CreateIndex(
                name: "IX_generators_eqId",
                table: "generators",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_gps_eqId",
                table: "gps",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_guncoms_eqId",
                table: "guncoms",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_gyros_eqId",
                table: "gyros",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_integratedHeadingSensors_eqId",
                table: "integratedHeadingSensors",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_MakeModels_eqTId",
                table: "MakeModels",
                column: "eqTId");

            migrationBuilder.CreateIndex(
                name: "IX_MakeModels_modelId",
                table: "MakeModels",
                column: "modelId");

            migrationBuilder.CreateIndex(
                name: "IX_miniSats_eqId",
                table: "miniSats",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_navtexs_eqId",
                table: "navtexs",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_procurements_equipCode",
                table: "procurements",
                column: "equipCode");

            migrationBuilder.CreateIndex(
                name: "IX_radars_eqId",
                table: "radars",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_sarts_eqId",
                table: "sarts",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_satCompasses_eqId",
                table: "satCompasses",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_satPhones_eqId",
                table: "satPhones",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_sonars_eqId",
                table: "sonars",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_spareProcurements_procuId",
                table: "spareProcurements",
                column: "procuId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_speedLogs_eqId",
                table: "speedLogs",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_subUnits_baseId",
                table: "subUnits",
                column: "baseId");

            migrationBuilder.CreateIndex(
                name: "IX_weapons_Ammunitionid",
                table: "weapons",
                column: "Ammunitionid");

            migrationBuilder.CreateIndex(
                name: "IX_weapons_CanonTypeid",
                table: "weapons",
                column: "CanonTypeid");

            migrationBuilder.CreateIndex(
                name: "IX_weapons_Countryid",
                table: "weapons",
                column: "Countryid");

            migrationBuilder.CreateIndex(
                name: "IX_weapons_eqId",
                table: "weapons",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_xenonS_eqId",
                table: "xenonS",
                column: "eqId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ais");

            migrationBuilder.DropTable(
                name: "anemometers");

            migrationBuilder.DropTable(
                name: "cCTVs");

            migrationBuilder.DropTable(
                name: "communications");

            migrationBuilder.DropTable(
                name: "dVRs");

            migrationBuilder.DropTable(
                name: "eCDIs");

            migrationBuilder.DropTable(
                name: "engines");

            migrationBuilder.DropTable(
                name: "eODs");

            migrationBuilder.DropTable(
                name: "epirbs");

            migrationBuilder.DropTable(
                name: "equipmentProcurements");

            migrationBuilder.DropTable(
                name: "EquipProcuView");

            migrationBuilder.DropTable(
                name: "generators");

            migrationBuilder.DropTable(
                name: "gps");

            migrationBuilder.DropTable(
                name: "guncoms");

            migrationBuilder.DropTable(
                name: "gyros");

            migrationBuilder.DropTable(
                name: "integratedHeadingSensors");

            migrationBuilder.DropTable(
                name: "MakeModels");

            migrationBuilder.DropTable(
                name: "miniSats");

            migrationBuilder.DropTable(
                name: "navtexs");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "radars");

            migrationBuilder.DropTable(
                name: "sarts");

            migrationBuilder.DropTable(
                name: "satCompasses");

            migrationBuilder.DropTable(
                name: "satPhones");

            migrationBuilder.DropTable(
                name: "sonars");

            migrationBuilder.DropTable(
                name: "spareProcurements");

            migrationBuilder.DropTable(
                name: "SpareProcuView");

            migrationBuilder.DropTable(
                name: "speedLogs");

            migrationBuilder.DropTable(
                name: "subUnits");

            migrationBuilder.DropTable(
                name: "weapons");

            migrationBuilder.DropTable(
                name: "xenonS");

            migrationBuilder.DropTable(
                name: "Makes");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "procurements");

            migrationBuilder.DropTable(
                name: "ammunitions");

            migrationBuilder.DropTable(
                name: "canonTypes");

            migrationBuilder.DropTable(
                name: "countries");

            migrationBuilder.DropTable(
                name: "equipments");

            migrationBuilder.DropTable(
                name: "bases");

            migrationBuilder.DropTable(
                name: "equipment_Tables");

            migrationBuilder.DropTable(
                name: "areas");

            migrationBuilder.DropTable(
                name: "ShipType");
        }
    }
}
