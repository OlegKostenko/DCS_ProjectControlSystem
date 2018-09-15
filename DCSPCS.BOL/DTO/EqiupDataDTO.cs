using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCSPCS.BOL.DTO
{
    public class EqiupDataDTO
    {
        public int EquipDataID { get; set; }
        public int EquipCategoryID { get; set; }
        public string EquipCategoryName { get; set; }
        public int EquipVendorID { get; set; }
        [Required]
        [StringLength(50)]
        public string EquipVendorName { get; set; }
        [Required]
        [StringLength(12)]
        public string EquipPartNumber { get; set; }
        [Required]
        [StringLength(50)]
        public string EqiupModelNumber { get; set; }
        public int EquipDescrID { get; set; }
        public string EquipDescr { get; set; }
        public int PREquipID { get; set; }
        public int PRID { get; set; }
        [StringLength(8)]
        public string EqiupPowerType { get; set; }
        public float? EqiupCurrent24VDC { get; set; }
        public string EqiupCurrentUnits { get; set; }
        public float? EqiupHeatDissipation { get; set; }
        public string EqiupHeatDissipationUnits { get; set; }
        public float? EqiupHeight { get; set; }
        public float? EqiupWidth { get; set; }
        public float? EqiupLength { get; set; }
        public string EqiupDimensionUnits { get; set; }
        public float? EqiupWeight { get; set; }
        public string EqiupWeightUnits { get; set; }
        public decimal? EqiupPrice { get; set; }
        public string EqiupPriceCurrency { get; set; }
        public DateTime? EqiupPriceDate { get; set; }
        public int WREquipID { get; set; }
    }
}
