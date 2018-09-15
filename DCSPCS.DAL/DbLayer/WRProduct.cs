namespace DCSPCS.DAL.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WRProduct")]
    public partial class WRProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WRProduct()
        {
            WREquipments = new HashSet<WREquipment>();
        }

        [Key]
        public int WRProdID { get; set; }

        [Required]
        [StringLength(15)]
        public string WRProdName { get; set; }

        [Required]
        [StringLength(100)]
        public string WRProdDesc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WREquipment> WREquipments { get; set; }
    }
}
