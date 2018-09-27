using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using DCSPCS.BOL.DTO;
using DCSPCS.DAL.DbLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Template.Repository.Common;

namespace DCSPCS.BOL.Services
{
    public class EquipCategoryService : IEntityService<EquipCategoryDTO>
    {
        IGenericRepository<EquipCategory> repository;
        readonly IMapper mapper;
        public EquipCategoryService(IGenericRepository<EquipCategory> repository)
        {
            this.repository = repository;
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<EquipCategory, EquipCategoryDTO>()
                        .ForMember("EquipCategoryID", opt => opt.MapFrom(c => c.EquipCategoryID))
                        .ForMember("EquipCategoryName", opt => opt.MapFrom(c => c.EquipCategoryName))
                        .ForMember("EquipDataID", opt => opt.MapFrom(c => c.EqiupDatas.Select(s => s.EquipDataID)));

                cfg.CreateMap<EquipCategoryDTO, EquipCategory>();
            }).CreateMapper();
        }

        public IEnumerable<EquipCategoryDTO> GetAll()
        {
            return repository.GetAll().Select(a => mapper.Map<EquipCategoryDTO>(a));
        }

        public EquipCategoryDTO Get(int? id)
        {
            if (id == null)
            {
                throw new Exception("Не установлено id категории");
            }

            var equipCategory = repository.Get(id.Value);
            if (equipCategory == null)
                throw new Exception("Каткгория не найдена");
            return mapper.Map<EquipCategoryDTO>(repository.Get(id.Value));
        }

        public IEnumerable<EquipCategoryDTO> FindBy(Expression<Func<EquipCategoryDTO, bool>> predicate)
        {
            Expression<Func<EquipCategory, bool>> expr = mapper.Map<Expression<Func<EquipCategoryDTO, bool>>, Expression<Func<EquipCategory, bool>>>(predicate);
            return repository.FindBy(expr).Select(a => mapper.Map<EquipCategoryDTO>(a));
        }

        public void AddOrUpdate(EquipCategoryDTO obj)
        {
            repository.AddOrUpdate(mapper.Map<EquipCategory>(obj));
        }

        public void Delete(EquipCategoryDTO obj)
        {
            repository.Delete(mapper.Map<EquipCategory>(obj));
        }
    }
}
