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
    public class EqiupDataService : IEntityService<EqiupDataDTO>
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
                        .ForMember("EquipDataID", opt => opt.MapFrom(c => c.EquipDataID))
                        .ForMember("EquipCategoryID", opt => opt.MapFrom(c => c.EquipCategoryID))
                        .ForMember("EquipCategoryName", opt => opt.MapFrom(c => c.EquipCategory.EquipCategoryName))
                        .ForMember("EquipVendorID", opt => opt.MapFrom(c => c.EquipVendorID))
                        .ForMember("EquipVendorName", opt => opt.MapFrom(c => c.EquipVendor.EquipVendorName))
                        .ForMember("EquipPartNumber", opt => opt.MapFrom(c => c.EquipPartNumber))
                        .ForMember("EqiupModelNumber", opt => opt.MapFrom(c => c.EqiupModelNumber))
                        .ForMember("EquipDescrID", opt => opt.MapFrom(c => c.EquipDescrID))
                        .ForMember("EquipDescr", opt => opt.MapFrom(c => c.EquipDescription.EquipDescr))
                        .ForMember("EqiupPowerType", opt => opt.MapFrom(c => c.EqiupPowerType))
                        .ForMember("EqiupCurrent24VDC", opt => opt.MapFrom(c => c.EqiupCurrent24VDC))
                        .ForMember("EqiupCurrentUnits", opt => opt.MapFrom(c => c.EqiupCurrentUnits))
                        .ForMember("EqiupHeatDissipation", opt => opt.MapFrom(c => c.EqiupHeatDissipation))
                        .ForMember("EqiupHeatDissipationUnits", opt => opt.MapFrom(c => c.EqiupHeatDissipationUnits))
                        .ForMember("EqiupHeight", opt => opt.MapFrom(c => c.EqiupHeight))
                        .ForMember("EqiupLength", opt => opt.MapFrom(c => c.EqiupLength))
                        .ForMember("EqiupDimensionUnits", opt => opt.MapFrom(c => c.EqiupDimensionUnits))
                        .ForMember("EqiupWeight", opt => opt.MapFrom(c => c.EqiupWeight))
                        .ForMember("EqiupPrice", opt => opt.MapFrom(c => c.EqiupPrice))
                        .ForMember("EqiupPriceCurrency", opt => opt.MapFrom(c => c.EqiupPriceCurrency))
                        .ForMember("EqiupPriceDate", opt => opt.MapFrom(c => c.EqiupPriceDate))
                        .ForMember("PREquipID", opt => opt.MapFrom(c => c.PREquipments.Select(s => s.PREquipID)))
                        .ForMember("WREquipID", opt => opt.MapFrom(c => c.WREquipments.Select(d => d.WREquipID)));

                cfg.CreateMap<EqiupDataDTO, EqiupData>();
            }).CreateMapper();
        }

        public IEnumerable<EqiupDataDTO> GetAll()
        {
            return repository.GetAll().Select(a=>mapper.Map<EqiupDataDTO>(a));
        }

        public EqiupDataDTO Get(int? id)
        {
            if (id == null)
            {
                throw new Exception("Не установлено id");
            }

            var equipData = repository.Get(id.Value);
            if (equipData == null)
                throw new Exception("Иноформация не найдена");
            return mapper.Map<EqiupDataDTO>(repository.Get(id.Value));
        }

        public IEnumerable<EqiupDataDTO> FindBy(Expression<Func<EqiupDataDTO, bool>> predicate)
        {
            Expression<Func<EqiupData, bool>> expr = mapper.Map<Expression<Func<EqiupDataDTO, bool>>, Expression<Func<EqiupData, bool>>>(predicate);
            return repository.FindBy(expr).Select(a => mapper.Map<EqiupDataDTO>(a));
        }

        public void AddOrUpdate(EqiupDataDTO obj)
        {
            repository.AddOrUpdate(mapper.Map<EqiupData>(obj));
        }

        public void Delete(EqiupDataDTO obj)
        {
            repository.Delete(mapper.Map<EqiupData>(obj));
        }


    }
}
