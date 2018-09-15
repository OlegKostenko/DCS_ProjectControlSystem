using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Template.Repository.Common;

namespace DCSPCS.WebUI.Models
{
    public class EquipmentByVendor
    {
        //IGenericRepository<WREquipment> EquipRepo;
        //IGenericRepository<WREquipVendor> VendorRepo;

        //public EquipmentByVendor(IGenericRepository<WREquipment> equipRepo,
        //    IGenericRepository<WREquipVendor> vendorRepo)
        //{
        //    EquipRepo = equipRepo;
        //    VendorRepo = vendorRepo;
        //}

        //public SelectList VendorId
        //{
        //    get
        //    {
        //        return new SelectList(VendorRepo.GetAll(),
        //            "WREquipVendorID", "WREquipVendorName");

        //    }
        //}
        public int CurrentVendorId { get; set; }
        //public IEnumerable<WREquipment> EquipByVendor
        //{
        //    get
        //    {
        //        return EquipRepo.FindBy(i => i.WREquipVendorID == CurrentVendorId);
        //    }
        //}
    }
}