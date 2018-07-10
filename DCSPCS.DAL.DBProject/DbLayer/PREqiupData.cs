namespace DCSPCS.DAL.DBProject.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PREqiupData")]
    public partial class PREqiupData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PREqiupData()
        {
            PREquipments = new HashSet<PREquipment>();
        }

        [Key]
        public long PREquipDataID { get; set; }

        public int PREquipVendorID { get; set; }

        [Required]
        [StringLength(12)]
        public string PREquipPartNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string PREqiupModelNumber { get; set; }

        public long PREquipDescrID { get; set; }

        [StringLength(8)]
        public string PREqiupPowerType { get; set; }

        public float? PREqiupCurrent24VDC { get; set; }

        [StringLength(3)]
        public string PREqiupCurrentUnits { get; set; }

        public float? PREqiupHeatDissipation { get; set; }

        [StringLength(5)]
        public string PREqiupHeatDissipationUnits { get; set; }

        public float? PREqiupHeight { get; set; }

        public float? PREqiupWidth { get; set; }

        public float? PREqiupLength { get; set; }

        [StringLength(7)]
        public string PREqiupDimensionUnits { get; set; }

        public float? PREqiupWeight { get; set; }

        [StringLength(7)]
        public string PREqiupWeightUnits { get; set; }

        [Column(TypeName = "money")]
        public decimal? PREqiupPrice { get; set; }

        [StringLength(3)]
        public string PREqiupPriceCurrency { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PREqiupPriceDate { get; set; }

        public virtual PREquipVendor PREquipVendor { get; set; }

        public virtual PREquipDescription PREquipDescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PREquipment> PREquipments { get; set; }
    }
}
