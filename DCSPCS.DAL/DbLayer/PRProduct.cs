namespace DCSPCS.DAL.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PRProduct")]
    public partial class PRProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRProduct()
        {
            PREquipments = new HashSet<PREquipment>();
        }

        [Key]
        public int PRProdID { get; set; }

        [Required]
        [StringLength(15)]
        public string PRProdName { get; set; }

        [Required]
        [StringLength(100)]
        public string PRProdDesc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PREquipment> PREquipments { get; set; }
    }
}
