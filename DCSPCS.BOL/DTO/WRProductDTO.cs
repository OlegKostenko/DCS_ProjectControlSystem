using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCSPCS.BOL.DTO
{
    public class WRProductDTO
    {
        public int WRProdID { get; set; }

        [Required]
        [StringLength(15)]
        public string WRProdName { get; set; }

        [Required]
        [StringLength(100)]
        public string WRProdDesc { get; set; }
    }
}
