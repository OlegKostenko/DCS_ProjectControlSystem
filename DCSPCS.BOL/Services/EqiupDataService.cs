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
    public class EqiupDataService //: IEntityService<EquipDataDTO>
    {
        IGenericRepository<EqiupData> repository;
        readonly IMapper mapper;

        public EqiupDataService(IGenericRepository<EqiupData> repository)
        {
            this.repository = repository;
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<EqiupData, EqiupDataDTO>()
                        .ForMember("CategoryID", opt => opt.MapFrom(c => c.EquipCategoryID))
                        .ForMember("CategoryName", opt => opt.MapFrom(c => c.EquipCategory.EquipCategoryName))
                        .ForMember("EquipVendorID", opt => opt.MapFrom(c => c.EquipVendorID)).ForMember("EquipVendorName", opt => opt.MapFrom(c => c.EquipVendor.EquipVendorName)).ForMember("EquipDescrID", opt => opt.MapFrom(c => c.EquipDescrID)).ForMember("EquipDescr", opt => opt.MapFrom(c => c.EquipDescription.EquipDescr))
                        .ForMember("PREquipID", opt => opt.MapFrom(c => c.PREquipments.Select(s => s.PREquipID))).ForMember("WREquipID", opt => opt.MapFrom(c => c.WREquipments.Select(s => s.WREquipID)));

                cfg.CreateMap<EquipDataDTO, EqiupData>();
            }).CreateMapper();
        }

        public IEnumerable<EqiupDataDTO> GetAll()
        {
            return (IEnumerable<EqiupDataDTO>)repository.GetAll().Select(a => mapper.Map<EquipDataDTO>(a));
        }

        public EquipDataDTO Get(int? id)
        {
            if (id == null)
            {
                throw new Exception("Не установлено id");
            }

            var equipCategory = repository.Get(id.Value);
            if (equipCategory == null)
                throw new Exception("Иноформация не найдена");
            return mapper.Map<EquipDataDTO>(repository.Get(id.Value));
        }

        public IEnumerable<EquipDataDTO> FindBy(Expression<Func<EquipDataDTO, bool>> predicate)
        {
            Expression<Func<EqiupData, bool>> expr = mapper.Map<Expression<Func<EquipDataDTO, bool>>, Expression<Func<EqiupData, bool>>>(predicate);
            return repository.FindBy(expr).Select(a => mapper.Map<EquipDataDTO>(a));
        }

        public void AddOrUpdate(EquipDataDTO obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(EquipDataDTO obj)
        {
            //mapper.Map<EquipDataDTO>(repository.Delete(obj));
        }

    }
}
