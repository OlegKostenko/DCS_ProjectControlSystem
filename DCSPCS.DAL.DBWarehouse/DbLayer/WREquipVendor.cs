namespace DCSPCS.DAL.DBWarehouse.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WREquipVendor")]
    public partial class WREquipVendor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WREquipVendor()
        {
            WREquipments = new HashSet<WREquipment>();
        }

        public int WREquipVendorID { get; set; }

        [Required]
        [StringLength(50)]
        public string WREquipVendorName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WREquipment> WREquipments { get; set; }
    }
}
