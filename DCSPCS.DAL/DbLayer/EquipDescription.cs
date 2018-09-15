namespace DCSPCS.DAL.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EquipDescription")]
    public partial class EquipDescription
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EquipDescription()
        {
            EqiupDatas = new HashSet<EqiupData>();
        }

        [Key]
        public int EquipDescrID { get; set; }

        [Required]
        [StringLength(200)]
        public string EquipDescr { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EqiupData> EqiupDatas { get; set; }
    }
}
