using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using DCSPCS.BOL.DTO;
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
    public class EquipCategoryService
    {
        IGenericRepository<EquipCategory> repository;
        readonly IMapper mapper;
        public EquipCategoryService(IGenericRepository<EquipCategory> repository)
        {
            this.repository = repository;
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<EquipCategory, EquipDataDTO>()
                        .ForMember("CategoryID", opt => opt.MapFrom(c => c.EquipCategoryID))
                        .ForMember("CategoryName", opt => opt.MapFrom(c => c.EquipCategoryName));

                cfg.CreateMap<EquipDataDTO, EquipCategory>();
            }).CreateMapper();
        }

        public IEnumerable<EquipDataDTO> GetCategorys()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            return repository.GetAll().Select(a => mapper.Map<EquipDataDTO>(a));
        }

        public EquipDataDTO GetCategory(int? id)
        {
            if (id == null)
            {
                throw new Exception("Не установлено id категории");
            }

            var equipCategory = repository.Get(id.Value);
            if (equipCategory == null)
                throw new Exception("Каткгория не найдена");
            return mapper.Map<EquipDataDTO>(repository.Get(id.Value));
            //return new EquipCategoryDTO { EquipCategoryName = equipCategory.EquipCategoryName,
             //EquipCategoryID = equipCategory.EquipCategoryID };
        }
    }
}
