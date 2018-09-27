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
    public class PRProductService : IEntityService<PRProductDTO>
    {
        IGenericRepository<PRProduct> repository;
        readonly IMapper mapper;

        public PRProductService(IGenericRepository<PRProduct> repository)
        {
            this.repository = repository;
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<PRProduct, PRProductDTO>()
                        .ForMember("PRProdID", opt => opt.MapFrom(c => c.PRProdID))
                        .ForMember("PRProdName", opt => opt.MapFrom(c => c.PRProdName))
                        .ForMember("PRProdDesc", opt => opt.MapFrom(c => c.PRProdDesc))
                        .ForMember("PREquipID", opt => opt.MapFrom(c => c.PREquipments.Select(s => s.PREquipID)));

                cfg.CreateMap<PRProductDTO, PRProduct>();
            }).CreateMapper();
        }

        public IEnumerable<PRProductDTO> GetAll()
        {
            return repository.GetAll().Select(a => mapper.Map<PRProductDTO>(a));
        }

        public PRProductDTO Get(int? id)
        {
            if (id == null)
            {
                throw new Exception("Не установлено id");
            }

            var equipCategory = repository.Get(id.Value);
            if (equipCategory == null)
                throw new Exception("Иноформация не найдена");
            return mapper.Map<PRProductDTO>(repository.Get(id.Value));
        }

        public IEnumerable<PRProductDTO> FindBy(Expression<Func<PRProductDTO, bool>> predicate)
        {
            Expression<Func<PRProduct, bool>> expr = mapper.Map<Expression<Func<PRProductDTO, bool>>, Expression<Func<PRProduct, bool>>>(predicate);
            return repository.FindBy(expr).Select(a => mapper.Map<PRProductDTO>(a));
        }

        public void AddOrUpdate(PRProductDTO obj)
        {
            repository.AddOrUpdate(mapper.Map<PRProduct>(obj));
        }

        public void Delete(PRProductDTO obj)
        {
            repository.Delete(mapper.Map<PRProduct>(obj));
        }
    }
}
