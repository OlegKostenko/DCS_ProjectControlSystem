using DCSPCS.DAL.DbLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCSPCS.BOL.DTO
{
    public class EquipVendorDTO
    {
        public int EquipVendorID { get; set; }

        [Required]
        [StringLength(50)]
        public string EquipVendorName { get; set; }

        public int EquipDataID { get; set; }
    }
}
