namespace DCSPCS.DAL.DBProject.DbLayer
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
        public long PREquipID { get; set; }

        public long PRID { get; set; }

        public long? PRProdID { get; set; }

        public long PREquipDataID { get; set; }

        public float PREquipQty { get; set; }

        [Required]
        [StringLength(10)]
        public string PREquipUnits { get; set; }

        public virtual PRDescription PRDescription { get; set; }

        public virtual PREqiupData PREqiupData { get; set; }

        public virtual PRProduct PRProduct { get; set; }
    }
}
