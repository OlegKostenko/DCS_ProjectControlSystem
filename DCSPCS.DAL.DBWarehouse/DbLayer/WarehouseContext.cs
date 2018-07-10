namespace DCSPCS.DAL.DBWarehouse.DbLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WarehouseContext : DbContext
    {
        public WarehouseContext()
            : base("name=WarehouseContext")
        {
        }

        public virtual DbSet<WREquipment> WREquipments { get; set; }
        public virtual DbSet<WREquipVendor> WREquipVendors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WREquipVendor>()
                .HasMany(e => e.WREquipments)
                .WithRequired(e => e.WREquipVendor)
                .WillCascadeOnDelete(false);
        }
    }
}
