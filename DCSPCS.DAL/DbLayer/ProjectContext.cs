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

        public virtual DbSet<PRDescription> PRDescriptions { get; set; }
        public virtual DbSet<PREquipment> PREquipments { get; set; }
        public virtual DbSet<PREquipVendor> PREquipVendors { get; set; }
        public virtual DbSet<PRProduct> PRProducts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PRDescription>()
                .HasMany(e => e.PREquipments)
                .WithRequired(e => e.PRDescription)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PREquipVendor>()
                .HasMany(e => e.PREquipments)
                .WithRequired(e => e.PREquipVendor)
                .WillCascadeOnDelete(false);
        }
    }
}
