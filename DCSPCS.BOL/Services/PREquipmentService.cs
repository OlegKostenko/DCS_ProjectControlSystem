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
    public class PREquipmentService : IEntityService<PREquipmentDTO>
    {
        IGenericRepository<PREquipment> repository;
        readonly IMapper mapper;

        public PREquipmentService(IGenericRepository<PREquipment> repository)
        {
            this.repository = repository;
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<PREquipment, PREquipmentDTO>()
                        .ForMember("PREquipID", opt => opt.MapFrom(c => c.PREquipID))
                        .ForMember("PRID", opt => opt.MapFrom(c => c.PRID))
                        .ForMember("PRProdID", opt => opt.MapFrom(c => c.PRProdID))
                        .ForMember("EquipDataID", opt => opt.MapFrom(c => c.EquipDataID))
                        .ForMember("PREquipQty", opt => opt.MapFrom(c => c.PREquipQty))
                        .ForMember("PREquipUnits", opt => opt.MapFrom(c => c.PREquipUnits));

                cfg.CreateMap<PREquipmentDTO, PREquipment>();
            }).CreateMapper();
        }

        public IEnumerable<PREquipmentDTO> GetAll()
        {
            return repository.GetAll().Select(a => mapper.Map<PREquipmentDTO>(a));
        }

        public PREquipmentDTO Get(int? id)
        {
            if (id == null)
            {
                throw new Exception("Не установлено id");
            }

            var equipCategory = repository.Get(id.Value);
            if (equipCategory == null)
                throw new Exception("Иноформация не найдена");
            return mapper.Map<PREquipmentDTO>(repository.Get(id.Value));
        }

        public IEnumerable<PREquipmentDTO> FindBy(Expression<Func<PREquipmentDTO, bool>> predicate)
        {
            Expression<Func<PREquipment, bool>> expr = mapper.Map<Expression<Func<PREquipmentDTO, bool>>, Expression<Func<PREquipment, bool>>>(predicate);
            return repository.FindBy(expr).Select(a => mapper.Map<PREquipmentDTO>(a));
        }

        public void AddOrUpdate(PREquipmentDTO obj)
        {
            repository.AddOrUpdate(mapper.Map<PREquipment>(obj));
        }

        public void Delete(PREquipmentDTO obj)
        {
            repository.Delete(mapper.Map<PREquipment>(obj));
        }
    }
}
