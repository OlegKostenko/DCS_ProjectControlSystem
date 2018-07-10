namespace DCSPCS.DAL.DBProject.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PREquipDescription")]
    public partial class PREquipDescription
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PREquipDescription()
        {
            PREqiupDatas = new HashSet<PREqiupData>();
        }

        [Key]
        public long PREquipDescrID { get; set; }

        [Required]
        [StringLength(200)]
        public string PREquipDescr { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PREqiupData> PREqiupDatas { get; set; }
    }
}
