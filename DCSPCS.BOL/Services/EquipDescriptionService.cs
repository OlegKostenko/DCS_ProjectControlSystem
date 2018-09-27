using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
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
    public class EquipDescriptionService : IEntityService<EquipDescriptionDTO>
    {
        IGenericRepository<EquipDescription> repository;
        readonly IMapper mapper;
        public EquipDescriptionService(IGenericRepository<EquipDescription> repository)
        {
            this.repository = repository;
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<EquipDescription, EquipDescriptionDTO>()
                        .ForMember("EquipDescrID", opt => opt.MapFrom(c => c.EquipDescrID))
                        .ForMember("EquipDescr", opt => opt.MapFrom(c => c.EquipDescr))
                        .ForMember("EquipDataID", opt => opt.MapFrom(c => c.EqiupDatas.Select(s => s.EquipDataID)));

                cfg.CreateMap<EquipDescriptionDTO, EquipDescription>();
            }).CreateMapper();
        }

        public IEnumerable<EquipDescriptionDTO> GetAll()
        {
            return repository.GetAll().Select(a => mapper.Map<EquipDescriptionDTO>(a));
        }

        public EquipDescriptionDTO Get(int? id)
        {
            if (id == null)
            {
                throw new Exception("Не установлено id категории");
            }

            var equipCategory = repository.Get(id.Value);
            if (equipCategory == null)
                throw new Exception("Каткгория не найдена");
            return mapper.Map<EquipDescriptionDTO>(repository.Get(id.Value));
        }

        public IEnumerable<EquipDescriptionDTO> FindBy(Expression<Func<EquipDescriptionDTO, bool>> predicate)
        {
            Expression<Func<EquipDescription, bool>> expr = mapper.Map<Expression<Func<EquipDescriptionDTO, bool>>, Expression<Func<EquipDescription, bool>>>(predicate);
            return repository.FindBy(expr).Select(a => mapper.Map<EquipDescriptionDTO>(a));
        }

        public void AddOrUpdate(EquipDescriptionDTO obj)
        {
            repository.AddOrUpdate(mapper.Map<EquipDescription>(obj));
        }

        public void Delete(EquipDescriptionDTO obj)
        {
            repository.Delete(mapper.Map<EquipDescription>(obj));
        }
    }
}
