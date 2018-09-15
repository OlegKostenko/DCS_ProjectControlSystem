namespace DCSPCS.DAL.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EqiupData")]
    public partial class EqiupData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EqiupData()
        {
            PREquipments = new HashSet<PREquipment>();
            WREquipments = new HashSet<WREquipment>();
        }

        [Key]
        public int EquipDataID { get; set; }

        public int EquipCategoryID { get; set; }

        public int EquipVendorID { get; set; }

        [Required]
        [StringLength(12)]
        public string EquipPartNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string EqiupModelNumber { get; set; }

        public int EquipDescrID { get; set; }

        [StringLength(8)]
        public string EqiupPowerType { get; set; }

        public float? EqiupCurrent24VDC { get; set; }

        [StringLength(3)]
        public string EqiupCurrentUnits { get; set; }

        public float? EqiupHeatDissipation { get; set; }

        [StringLength(5)]
        public string EqiupHeatDissipationUnits { get; set; }

        public float? EqiupHeight { get; set; }

        public float? EqiupWidth { get; set; }

        public float? EqiupLength { get; set; }

        [StringLength(7)]
        public string EqiupDimensionUnits { get; set; }

        public float? EqiupWeight { get; set; }

        [StringLength(7)]
        public string EqiupWeightUnits { get; set; }

        [Column(TypeName = "money")]
        public decimal? EqiupPrice { get; set; }

        [StringLength(3)]
        public string EqiupPriceCurrency { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EqiupPriceDate { get; set; }

        public virtual EquipCategory EquipCategory { get; set; }

        public virtual EquipVendor EquipVendor { get; set; }

        public virtual EquipDescription EquipDescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PREquipment> PREquipments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WREquipment> WREquipments { get; set; }
    }
}
