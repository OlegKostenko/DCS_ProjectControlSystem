using DCSPCS.BOL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCSPCS.BOL.Services
{
    public class EquipDescriptionDTO
    {
        public int EquipDescrID { get; set; }
        public string EquipDescr { get; set; }
        public ICollection<EqiupDataDTO> EqiupDatas { get; set; }
    }
}
