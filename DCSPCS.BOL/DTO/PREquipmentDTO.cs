using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCSPCS.BOL.DTO
{
    public class PREquipmentDTO
    {
        public int PREquipID { get; set; }

        public int PRID { get; set; }

        public int? PRProdID { get; set; }

        public int EquipDataID { get; set; }

        public float PREquipQty { get; set; }

        [Required]
        [StringLength(10)]
        public string PREquipUnits { get; set; }

    }
}
