using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityExtension.Migrations.DnlDB
{
    public partial class updateEquipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_xenonS_eqId",
                table: "xenonS");

            migrationBuilder.DropIndex(
                name: "IX_weapons_eqId",
                table: "weapons");

            migrationBuilder.DropIndex(
                name: "IX_speedLogs_eqId",
                table: "speedLogs");

            migrationBuilder.DropIndex(
                name: "IX_sonars_eqId",
                table: "sonars");

            migrationBuilder.DropIndex(
                name: "IX_satPhones_eqId",
                table: "satPhones");

            migrationBuilder.DropIndex(
                name: "IX_satCompasses_eqId",
                table: "satCompasses");

            migrationBuilder.DropIndex(
                name: "IX_sarts_eqId",
                table: "sarts");

            migrationBuilder.DropIndex(
                name: "IX_radars_eqId",
                table: "radars");

            migrationBuilder.DropIndex(
                name: "IX_navtexs_eqId",
                table: "navtexs");

            migrationBuilder.DropIndex(
                name: "IX_miniSats_eqId",
                table: "miniSats");

            migrationBuilder.DropIndex(
                name: "IX_integratedHeadingSensors_eqId",
                table: "integratedHeadingSensors");

            migrationBuilder.DropIndex(
                name: "IX_gyros_eqId",
                table: "gyros");

            migrationBuilder.DropIndex(
                name: "IX_guncoms_eqId",
                table: "guncoms");

            migrationBuilder.DropIndex(
                name: "IX_gps_eqId",
                table: "gps");

            migrationBuilder.DropIndex(
                name: "IX_generators_eqId",
                table: "generators");

            migrationBuilder.DropIndex(
                name: "IX_epirbs_eqId",
                table: "epirbs");

            migrationBuilder.DropIndex(
                name: "IX_eODs_eqId",
                table: "eODs");

            migrationBuilder.DropIndex(
                name: "IX_eCDIs_eqId",
                table: "eCDIs");

            migrationBuilder.DropIndex(
                name: "IX_dVRs_eqId",
                table: "dVRs");

            migrationBuilder.DropIndex(
                name: "IX_communications_eqId",
                table: "communications");

            migrationBuilder.DropIndex(
                name: "IX_cCTVs_eqId",
                table: "cCTVs");

            migrationBuilder.DropIndex(
                name: "IX_anemometers_eqId",
                table: "anemometers");

            migrationBuilder.DropIndex(
                name: "IX_ais_eqId",
                table: "ais");

            migrationBuilder.CreateIndex(
                name: "IX_xenonS_eqId",
                table: "xenonS",
                column: "eqId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_weapons_eqId",
                table: "weapons",
                column: "eqId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_speedLogs_eqId",
                table: "speedLogs",
                column: "eqId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sonars_eqId",
                table: "sonars",
                column: "eqId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_satPhones_eqId",
                table: "satPhones",
                column: "eqId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_satCompasses_eqId",
                table: "satCompasses",
                column: "eqId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sarts_eqId",
                table: "sarts",
                column: "eqId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_radars_eqId",
                table: "radars",
                column: "eqId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_navtexs_eqId",
                table: "navtexs",
                column: "eqId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_miniSats_eqId",
                table: "miniSats",
                column: "eqId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_integratedHeadingSensors_eqId",
                table: "integratedHeadingSensors",
                column: "eqId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_gyros_eqId",
                table: "gyros",
                column: "eqId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_guncoms_eqId",
                table: "guncoms",
                column: "eqId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_gps_eqId",
                table: "gps",
                column: "eqId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_generators_eqId",
                table: "generators",
                column: "eqId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_epirbs_eqId",
                table: "epirbs",
                column: "eqId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_eODs_eqId",
                table: "eODs",
                column: "eqId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_eCDIs_eqId",
                table: "eCDIs",
                column: "eqId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_dVRs_eqId",
                table: "dVRs",
                column: "eqId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_communications_eqId",
                table: "communications",
                column: "eqId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cCTVs_eqId",
                table: "cCTVs",
                column: "eqId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_anemometers_eqId",
                table: "anemometers",
                column: "eqId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ais_eqId",
                table: "ais",
                column: "eqId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_xenonS_eqId",
                table: "xenonS");

            migrationBuilder.DropIndex(
                name: "IX_weapons_eqId",
                table: "weapons");

            migrationBuilder.DropIndex(
                name: "IX_speedLogs_eqId",
                table: "speedLogs");

            migrationBuilder.DropIndex(
                name: "IX_sonars_eqId",
                table: "sonars");

            migrationBuilder.DropIndex(
                name: "IX_satPhones_eqId",
                table: "satPhones");

            migrationBuilder.DropIndex(
                name: "IX_satCompasses_eqId",
                table: "satCompasses");

            migrationBuilder.DropIndex(
                name: "IX_sarts_eqId",
                table: "sarts");

            migrationBuilder.DropIndex(
                name: "IX_radars_eqId",
                table: "radars");

            migrationBuilder.DropIndex(
                name: "IX_navtexs_eqId",
                table: "navtexs");

            migrationBuilder.DropIndex(
                name: "IX_miniSats_eqId",
                table: "miniSats");

            migrationBuilder.DropIndex(
                name: "IX_integratedHeadingSensors_eqId",
                table: "integratedHeadingSensors");

            migrationBuilder.DropIndex(
                name: "IX_gyros_eqId",
                table: "gyros");

            migrationBuilder.DropIndex(
                name: "IX_guncoms_eqId",
                table: "guncoms");

            migrationBuilder.DropIndex(
                name: "IX_gps_eqId",
                table: "gps");

            migrationBuilder.DropIndex(
                name: "IX_generators_eqId",
                table: "generators");

            migrationBuilder.DropIndex(
                name: "IX_epirbs_eqId",
                table: "epirbs");

            migrationBuilder.DropIndex(
                name: "IX_eODs_eqId",
                table: "eODs");

            migrationBuilder.DropIndex(
                name: "IX_eCDIs_eqId",
                table: "eCDIs");

            migrationBuilder.DropIndex(
                name: "IX_dVRs_eqId",
                table: "dVRs");

            migrationBuilder.DropIndex(
                name: "IX_communications_eqId",
                table: "communications");

            migrationBuilder.DropIndex(
                name: "IX_cCTVs_eqId",
                table: "cCTVs");

            migrationBuilder.DropIndex(
                name: "IX_anemometers_eqId",
                table: "anemometers");

            migrationBuilder.DropIndex(
                name: "IX_ais_eqId",
                table: "ais");

            migrationBuilder.CreateIndex(
                name: "IX_xenonS_eqId",
                table: "xenonS",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_weapons_eqId",
                table: "weapons",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_speedLogs_eqId",
                table: "speedLogs",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_sonars_eqId",
                table: "sonars",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_satPhones_eqId",
                table: "satPhones",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_satCompasses_eqId",
                table: "satCompasses",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_sarts_eqId",
                table: "sarts",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_radars_eqId",
                table: "radars",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_navtexs_eqId",
                table: "navtexs",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_miniSats_eqId",
                table: "miniSats",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_integratedHeadingSensors_eqId",
                table: "integratedHeadingSensors",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_gyros_eqId",
                table: "gyros",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_guncoms_eqId",
                table: "guncoms",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_gps_eqId",
                table: "gps",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_generators_eqId",
                table: "generators",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_epirbs_eqId",
                table: "epirbs",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_eODs_eqId",
                table: "eODs",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_eCDIs_eqId",
                table: "eCDIs",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_dVRs_eqId",
                table: "dVRs",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_communications_eqId",
                table: "communications",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_cCTVs_eqId",
                table: "cCTVs",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_anemometers_eqId",
                table: "anemometers",
                column: "eqId");

            migrationBuilder.CreateIndex(
                name: "IX_ais_eqId",
                table: "ais",
                column: "eqId");
        }
    }
}
