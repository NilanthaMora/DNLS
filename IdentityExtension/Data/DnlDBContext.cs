using IdentityExtension.Models;
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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Procurement>()
             .HasOne(a => a.EquipmentProcurement)
             .WithOne(a => a.Procurement)
             .HasForeignKey<EquipmentProcurement>(c => c.procuId);

            modelBuilder.Entity<Procurement>()
            .HasOne(a => a.SpareProcurement)
            .WithOne(a => a.Procurement)
            .HasForeignKey<SpareProcurement>(c => c.procuId);

            modelBuilder.Entity<ApplicationUser>()
             .HasMany(a => a.Procurements)
             .WithOne(b => b.Application);
        }
    }

}
