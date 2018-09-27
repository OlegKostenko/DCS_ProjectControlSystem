using DCSPCS.BOL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCSPCS.BOL.Services
{
    public class EquipDescriptionDTO
    {
        public int EquipDescrID { get; set; }
        [Required]
        [StringLength(200)]
        public string EquipDescr { get; set; }
        public int EquipDataID { get; set; }
    }
}
