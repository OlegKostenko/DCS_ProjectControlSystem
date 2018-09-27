using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCSPCS.BOL.DTO
{
    public class PRDescriptionDTO
    {
        public int PRID { get; set; }

        [Required]
        [StringLength(15)]
        public string PRCode { get; set; }

        [Required]
        [StringLength(300)]
        public string PRName { get; set; }

        public long PREquipID { get; set; }
    }
}
