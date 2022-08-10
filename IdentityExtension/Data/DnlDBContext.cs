using IdentityExtension.Models;
using IdentityExtension.Models.Bill;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Data
{
    public class DnlDBContext: DbContext 
    {
        public DnlDBContext(DbContextOptions<DnlDBContext> options) : base(options)
        {

        }

        public DbSet<EquipmentTable> equipment_Tables { get; set; }
        public DbSet<Procurement> procurements { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<EquipmentProcurement> equipmentProcurements { get; set; }
        public DbSet<SpareProcurement> spareProcurements { get; set; }

        public DbSet<Engine> engines { get; set; }
        public DbSet<Radar> radars { get; set; }
        public DbSet<Gyro> gyros { get; set; }
        public DbSet<Generator> generators { get; set; }
        public DbSet<Communication> communications { get; set; }
        public DbSet<Sonar> sonars { get; set; }
        public DbSet<Gps> gps { get; set; }
        public DbSet<Guncom> guncoms { get; set; }
        public DbSet<Epirb> epirbs { get; set; }
        public DbSet<DVR> dVRs { get; set; }
        public DbSet<IntegratedHeadingSensor> integratedHeadingSensors { get; set; }
        public DbSet<Ais> ais { get; set; }
        public DbSet<CCTV> cCTVs { get; set; }
        public DbSet<EODs> eODs { get; set; }
        public DbSet<SatCompass> satCompasses { get; set; }
        public DbSet<SatPhone> satPhones { get; set; }
        public DbSet<Sart> sarts { get; set; }
        public DbSet<speedLog> speedLogs { get; set; }
        public DbSet<Anemometers> anemometers { get; set; }
        public DbSet<XenonSLight> xenonS { get; set; }
        public DbSet<Navtex> navtexs { get; set; }
        public DbSet<MiniSat> miniSats { get; set; }
        public DbSet<ECDI> eCDIs { get; set; }
        public DbSet<Weapon> weapons { get; set; }

        public DbSet<Country> countries { get; set; }
        public DbSet<Ammunition> ammunitions { get; set; }
        public DbSet<CanonType> canonTypes { get; set; }
        
        public DbSet<Area> areas { get; set; }
        public DbSet<Base> bases { get; set; }
        public DbSet<Equipment> equipments { get; set; }
        public DbSet<SubUnit> subUnits { get; set; }
        public DbSet<ShipType> shipTypes { get; set; }

        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<MakeModel> MakeModels { get; set; }

        public DbSet<ElectricityAccountBill> ElectricityAccountBills { get; set; }
        public DbSet<ElectricityBillDetail> ElectricityBillDetails { get; set; }
        public DbSet<ElectricityBillDetailBulk> ElectricityBillDetailBulks { get; set; }
        public DbSet<ElectricityBillDetailDomestic> ElectricityBillDetailDomestics { get; set; }
        public DbSet<ElectricityBillType> ElectricityBillTypes { get; set; }

        public DbSet<FuelBillAccount> FuelBillAccounts { get; set; }
        public DbSet<FuelBillDetail> FuelBillDetails { get; set; }
        public DbSet<FuelBillSubDetail> FuelBillSubDetails { get; set; }
        public DbSet<FuelBillType> FuelBillTypes { get; set; } 


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MakeModel>().HasKey(mm => new { mm.makeId, mm.modelId });

            modelBuilder.Entity<Procurement>()
             .HasOne(a => a.EquipmentProcurement)
             .WithOne(a => a.Procurement)
             .HasForeignKey<EquipmentProcurement>(c => c.procuId);

            modelBuilder.Entity<Procurement>()
            .HasOne(a => a.SpareProcurement)
            .WithOne(a => a.Procurement)
            .HasForeignKey<SpareProcurement>(c => c.procuId);

            modelBuilder.Entity<EquipmentTable>()
             .HasMany(a => a.Procurements)
             .WithOne(b => b.EquipmentTable)
             .HasForeignKey(c => c.equipCode);

            modelBuilder.Entity<ShipType>()
             .HasMany(a => a.Base)
             .WithOne(b => b.ShipType)
             .HasForeignKey(c => c.shipTypeId);

            // modelBuilder.Entity<ApplicationUser>()
            //  .HasMany(a => a.Procurements)
            //  .WithOne(b => b.Application);
        }


        public DbSet<IdentityExtension.Models.EquipProcuView> EquipProcuView { get; set; }


        public DbSet<IdentityExtension.Models.SpareProcuView> SpareProcuView { get; set; }


        public DbSet<IdentityExtension.Models.ShipType> ShipType { get; set; }
    }

}
