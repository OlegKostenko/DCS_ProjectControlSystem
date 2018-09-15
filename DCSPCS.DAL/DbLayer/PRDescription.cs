namespace DCSPCS.DAL.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PRDescription")]
    public partial class PRDescription
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRDescription()
        {
            PREquipments = new HashSet<PREquipment>();
        }

        [Key]
        public int PRID { get; set; }

        [Required]
        [StringLength(15)]
        public string PRCode { get; set; }

        [Required]
        [StringLength(300)]
        public string PRName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PREquipment> PREquipments { get; set; }
    }
}
