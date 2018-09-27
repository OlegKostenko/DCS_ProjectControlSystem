using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCSPCS.BOL.DTO
{
    public class PRProductDTO
    {
        public int PRProdID { get; set; }

        [Required]
        [StringLength(15)]
        public string PRProdName { get; set; }

        [Required]
        [StringLength(100)]
        public string PRProdDesc { get; set; }

        public int PREquipID { get; set; }
    }
}
