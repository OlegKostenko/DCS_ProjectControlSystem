namespace DCSPCS.DAL.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PREquipVendor")]
    public partial class PREquipVendor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PREquipVendor()
        {
            PREquipments = new HashSet<PREquipment>();
        }

        public int PREquipVendorID { get; set; }

        [Required]
        [StringLength(50)]
        public string PREquipVendorName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PREquipment> PREquipments { get; set; }
    }
}
