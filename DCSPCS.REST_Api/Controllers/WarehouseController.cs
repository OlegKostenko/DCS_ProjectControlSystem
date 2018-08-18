﻿using AutoMapper;
using DCSPCS.DAL.DBWarehouse.DbLayer;
using DCSPCS.Repository.Abstract;
using DCSPCS.Repository.Concrete;
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
        IMyContextFactory factory;

        public WarehouseController(IMyContextFactory factory)
        {
            this.factory = factory;
        }

        public IHttpActionResult GetAllItems()
        {
            //IEnumerable<PhoneDTO> phoneDtos = orderService.GetPhones();
            var context = factory.GetWarehouseContext();
            
            IEnumerable<WREquipment> repo = context.Set<WREquipment>().ToList();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<WREquipment, WREquipmentViewModel>()).CreateMapper();
            var equipmentViewModels = mapper.Map<IEnumerable<WREquipment>, List<WREquipmentViewModel>>(repo);

            return Ok(equipmentViewModels);

        }

        public IHttpActionResult Edit(int id)
        {
            var context = factory.GetWarehouseContext();
            IEnumerable<WREquipment> repo = context.Set<WREquipment>().ToList();
            if (id == 0)
                return NotFound();
            // Настройка AutoMapper
            Mapper.Initialize(cfg => cfg.CreateMap<WREquipment, WREquipmentViewModel>()
                    .ForMember("Id", opt => opt.MapFrom(src => src.WREquipID)));
            WREquipmentViewModel equipment = Mapper.Map<WREquipment, WREquipmentViewModel>(repo.Where(a => a.WREquipID == id).FirstOrDefault());
            return Ok(equipment);
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
