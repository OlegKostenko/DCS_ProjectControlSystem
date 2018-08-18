using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DCSPCS.WebUI.Models.Warehouse
{
    public class WREquipmentViewModel
    {
        public long WREquipID { get; set; }
        public int WREquipVendorID { get; set; }
        public string WREquipCode { get; set; }
        public string WREquipDescr { get; set; }
        public float WREquipQty { get; set; }
        public string WREquipUnits { get; set; }
    }
}