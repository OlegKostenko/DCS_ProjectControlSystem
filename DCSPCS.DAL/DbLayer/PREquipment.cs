namespace DCSPCS.DAL.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PREquipment")]
    public partial class PREquipment
    {
        [Key]
        public int PREquipID { get; set; }

        public int PRID { get; set; }

        public int? PRProdID { get; set; }

        public int EquipDataID { get; set; }

        public float PREquipQty { get; set; }

        [Required]
        [StringLength(10)]
        public string PREquipUnits { get; set; }

        public virtual EqiupData EqiupData { get; set; }

        public virtual PRDescription PRDescription { get; set; }

        public virtual PRProduct PRProduct { get; set; }
    }
}
