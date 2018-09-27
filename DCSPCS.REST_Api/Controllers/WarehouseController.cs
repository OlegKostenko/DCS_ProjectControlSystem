using AutoMapper;
using DCSPCS.BOL.DTO;
using DCSPCS.BOL.Services;
using DCSPCS.DAL.DbLayer;
using DCSPCS.REST_Api.Models.WarehouseViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DCSPCS.REST_Api.Controllers
{
    public class WarehouseController : ApiController
    {
        IEntityService<WREquipmentDTO> WREquipment;
        IEntityService<EquipVendorDTO> EqVendors;
        public WarehouseController(IEntityService<WREquipmentDTO> WREquipment, IEntityService<EquipVendorDTO> EqVendors)
        {
            this.WREquipment = WREquipment;
            this.EqVendors = EqVendors;
        }

        public IHttpActionResult GetAllItems()
        {
            return Ok(WREquipment.GetAll());
        }
        //public IHttpActionResult EquipmentList()
        //{
        //    return null;
        //}

        public IHttpActionResult Edit(int id)
        {

            return null;
        }

        //[HttpPost]
        //public IHttpActionResult Edit(WREquipmentViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Настройка AutoMapper
        //        Mapper.Initialize(cfg => cfg.CreateMap<WREquipment, WREquipmentViewModel>()
        //            .ForMember("Id", opt => opt.MapFrom(src => src.WREquipID)));
        //        // Выполняем сопоставление
        //        WREquipment equipment = Mapper.Map<WREquipmentViewModel, WREquipment>(model);

        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return View(product);
        //    }
        //}
        //public Reservation GetReservation(int id)
        //{
        //    return repo.Get(id);
        //}
        //public Reservation PostReservation(Reservation item)
        //{
        //    return repo.Add(item);
        //}
        //public bool PutReservation(Reservation item)
        //{
        //    return repo.Update(item);
        //}
        //public void DeleteReservation(int id)
        //{
        //    repo.Remove(id);
        //}
    } 
}
