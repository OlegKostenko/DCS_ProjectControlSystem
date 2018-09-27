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
    public class EquipVendorService : IEntityService<EquipVendorDTO>
    {
        IGenericRepository<EquipVendor> repository;
        readonly IMapper mapper;

        public EquipVendorService(IGenericRepository<EquipVendor> repository)
        {
            this.repository = repository;
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<EquipVendor, EquipVendorDTO>()
                        .ForMember("EquipVendorID", opt => opt.MapFrom(c => c.EquipVendorID))
                        .ForMember("EquipVendorName", opt => opt.MapFrom(c => c.EquipVendorName))
                        .ForMember("EquipDataID", opt => opt.MapFrom(c => c.EqiupDatas.Select(s => s.EquipDataID)));

                cfg.CreateMap<EquipVendorDTO, EquipVendor>();
            }).CreateMapper();
        }

        public IEnumerable<EquipVendorDTO> GetAll()
        {
            return repository.GetAll().Select(a => mapper.Map<EquipVendorDTO>(a));
        }

        public EquipVendorDTO Get(int? id)
        {
            if (id == null)
            {
                throw new Exception("Не установлено id");
            }

            var equipCategory = repository.Get(id.Value);
            if (equipCategory == null)
                throw new Exception("Иноформация не найдена");
            return mapper.Map<EquipVendorDTO>(repository.Get(id.Value));
        }

        public IEnumerable<EquipVendorDTO> FindBy(Expression<Func<EquipVendorDTO, bool>> predicate)
        {
            Expression<Func<EquipVendor, bool>> expr = mapper.Map<Expression<Func<EquipVendorDTO, bool>>, Expression<Func<EquipVendor, bool>>>(predicate);
            return repository.FindBy(expr).Select(a => mapper.Map<EquipVendorDTO>(a));
        }

        public void AddOrUpdate(EquipVendorDTO obj)
        {
            repository.AddOrUpdate(mapper.Map<EquipVendor>(obj));
        }

        public void Delete(EquipVendorDTO obj)
        {
            repository.Delete(mapper.Map<EquipVendor>(obj));
        }
    }
}
