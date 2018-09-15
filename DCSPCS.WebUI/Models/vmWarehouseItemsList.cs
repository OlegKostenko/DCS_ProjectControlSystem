using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace DCSPCS.WebUI.Models
{
    public class vmWarehouseItemsList
    {
        public PagingInfo paging { get; set; }
        public int VendorId { get; set; }

        public vmWarehouseItemsList()
        {
            paging = new PagingInfo() { CurrentPage = 1, ItemsPerPage = 5 };
        }

        //IQueryable<WREquipment> m_equipment;
        //public IQueryable<WREquipment> Equipment
        //{
        //    get { return m_equipment; }
        //    set
        //    {
        //        m_equipment = value;
        //        paging.TotalItems = (m_equipment == null) ? 0 : m_equipment.Count();
        //    }
        //}

        //public Expression<Func<WREquipment, bool>> predicate
        //{
        //    get
        //    {
        //        return c => c.WREquipVendorID == VendorId;
        //    }
        //}

        //public IEnumerable<WREquipment> EquipmentByPage
        //{
        //    get
        //    {
        //        return Equipment.OrderBy(c => c.WREquipUnits)
        //            .Skip((paging.CurrentPage - 1) * paging.ItemsPerPage)
        //            .Take(paging.ItemsPerPage);
        //    }

        //}
    }
}