namespace DCSPCS.DAL.DbLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProjectContext : DbContext
    {
        public ProjectContext()
            : base("name=ProjectContext")
        {
        }

        public virtual DbSet<EqiupData> EqiupDatas { get; set; }
        public virtual DbSet<EquipCategory> EquipCategories { get; set; }
        public virtual DbSet<EquipDescription> EquipDescriptions { get; set; }
        public virtual DbSet<EquipVendor> EquipVendors { get; set; }
        public virtual DbSet<PRDescription> PRDescriptions { get; set; }
        public virtual DbSet<PREquipment> PREquipments { get; set; }
        public virtual DbSet<PRProduct> PRProducts { get; set; }
        public virtual DbSet<WREquipment> WREquipments { get; set; }
        public virtual DbSet<WRProduct> WRProducts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EqiupData>()
                .Property(e => e.EqiupPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<EqiupData>()
                .HasMany(e => e.PREquipments)
                .WithRequired(e => e.EqiupData)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EqiupData>()
                .HasMany(e => e.WREquipments)
                .WithRequired(e => e.EqiupData)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EquipCategory>()
                .HasMany(e => e.EqiupDatas)
                .WithRequired(e => e.EquipCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EquipDescription>()
                .HasMany(e => e.EqiupDatas)
                .WithRequired(e => e.EquipDescription)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EquipVendor>()
                .HasMany(e => e.EqiupDatas)
                .WithRequired(e => e.EquipVendor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRDescription>()
                .HasMany(e => e.PREquipments)
                .WithRequired(e => e.PRDescription)
                .WillCascadeOnDelete(false);
        }
    }
}
