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
    public class WREquipmentService : IEntityService<WREquipmentDTO>
    {
        IGenericRepository<WREquipment> repository;
        readonly IMapper mapper;

        public WREquipmentService(IGenericRepository<WREquipment> repository)
        {
            this.repository = repository;
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<WREquipment, WREquipmentDTO>()
                        .ForMember("WREquipID", opt => opt.MapFrom(c => c.WREquipID))
                        .ForMember("WRProdID", opt => opt.MapFrom(c => c.WRProdID))
                        .ForMember("EquipDataID", opt => opt.MapFrom(c => c.EquipDataID))
                        .ForMember("WREquipQty", opt => opt.MapFrom(c => c.WREquipQty))
                        .ForMember("WREquipUnits", opt => opt.MapFrom(c => c.WREquipUnits));

                cfg.CreateMap<WREquipmentDTO, WREquipment>();
            }).CreateMapper();
        }

        public IEnumerable<WREquipmentDTO> GetAll()
        {
            return repository.GetAll().Select(a => mapper.Map<WREquipmentDTO>(a));
        }

        public WREquipmentDTO Get(int? id)
        {
            if (id == null)
            {
                throw new Exception("Не установлено id");
            }

            var equipCategory = repository.Get(id.Value);
            if (equipCategory == null)
                throw new Exception("Иноформация не найдена");
            return mapper.Map<WREquipmentDTO>(repository.Get(id.Value));
        }

        public IEnumerable<WREquipmentDTO> FindBy(Expression<Func<WREquipmentDTO, bool>> predicate)
        {
            Expression<Func<WREquipment, bool>> expr = mapper.Map<Expression<Func<WREquipmentDTO, bool>>, Expression<Func<WREquipment, bool>>>(predicate);
            return repository.FindBy(expr).Select(a => mapper.Map<WREquipmentDTO>(a));
        }

        public void AddOrUpdate(WREquipmentDTO obj)
        {
            repository.AddOrUpdate(mapper.Map<WREquipment>(obj));
        }

        public void Delete(WREquipmentDTO obj)
        {
            repository.Delete(mapper.Map<WREquipment>(obj));
        }
    }
}
