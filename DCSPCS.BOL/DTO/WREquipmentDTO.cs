using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCSPCS.BOL.DTO
{
    public class WREquipmentDTO
    {
        public int WREquipID { get; set; }

        public int? WRProdID { get; set; }

        public int EquipDataID { get; set; }

        public float? WREquipQty { get; set; }

        [Required]
        [StringLength(10)]
        public string WREquipUnits { get; set; }
    }
}
