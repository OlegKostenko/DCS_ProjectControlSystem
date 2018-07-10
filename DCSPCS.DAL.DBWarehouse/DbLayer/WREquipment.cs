namespace DCSPCS.DAL.DBWarehouse.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WREquipment")]
    public partial class WREquipment
    {
        [Key]
        public long WREquipID { get; set; }

        public int WREquipVendorID { get; set; }

        [Required]
        [StringLength(12)]
        public string WREquipCode { get; set; }

        [Required]
        [StringLength(200)]
        public string WREquipDescr { get; set; }

        public float WREquipQty { get; set; }

        [Required]
        [StringLength(10)]
        public string WREquipUnits { get; set; }

        public virtual WREquipVendor WREquipVendor { get; set; }
    }
}
