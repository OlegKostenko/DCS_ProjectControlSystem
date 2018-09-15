namespace DCSPCS.DAL.DbLayer
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
        public int WREquipID { get; set; }

        public int? WRProdID { get; set; }

        public int EquipDataID { get; set; }

        public float? WREquipQty { get; set; }

        [Required]
        [StringLength(10)]
        public string WREquipUnits { get; set; }

        public virtual EqiupData EqiupData { get; set; }

        public virtual WRProduct WRProduct { get; set; }
    }
}
