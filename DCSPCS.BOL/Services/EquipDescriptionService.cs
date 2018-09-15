using AutoMapper;
using DCSPCS.DAL.DbLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Repository.Common;

namespace DCSPCS.BOL.Services
{
    public class EquipDescriptionService
    {
        IGenericRepository<EquipDescription> repository;

        public EquipDescriptionService(IGenericRepository<EquipDescription> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<EquipDescriptionDTO> GetPhones()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EquipDescription, EquipDescriptionDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<EquipDescription>, List<EquipDescriptionDTO>>(repository.GetAll());
        }

        public EquipDescriptionDTO GetPhone(int? id)
        {
            if (id == null)
                throw new Exception("Не установлено id опысания");
            var equipDescription = repository.Get(id.Value);
            if (equipDescription == null)
                throw new Exception("Описание не найдено");

            return new EquipDescriptionDTO
            {
                //EqiupDatas = equipDescription.EqiupDatas,
                EquipDescr = equipDescription.EquipDescr,
                EquipDescrID = equipDescription.EquipDescrID
            };
        }
    }
}
