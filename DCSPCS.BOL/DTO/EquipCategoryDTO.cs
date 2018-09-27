using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCSPCS.BOL.DTO
{
    public class EquipCategoryDTO
    {
        public int EquipCategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string EquipCategoryName { get; set; }

        public int EquipDataID { get; set; }
    }
}
