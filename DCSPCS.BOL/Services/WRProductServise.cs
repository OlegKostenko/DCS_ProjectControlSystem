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
    public class WRProductServise : IEntityService<WRProductDTO>
    {
        IGenericRepository<WRProduct> repository;
        readonly IMapper mapper;

        public WRProductServise(IGenericRepository<WRProduct> repository)
        {
            this.repository = repository;
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<WRProduct, WRProductDTO>()
                        .ForMember("WRProdID", opt => opt.MapFrom(c => c.WRProdID))
                        .ForMember("WRProdName", opt => opt.MapFrom(c => c.WRProdName))
                        .ForMember("WRProdDesc", opt => opt.MapFrom(c => c.WRProdDesc));

                cfg.CreateMap<WRProductDTO, WRProduct>();
            }).CreateMapper();
        }

        public IEnumerable<WRProductDTO> GetAll()
        {
            return repository.GetAll().Select(a => mapper.Map<WRProductDTO>(a));
        }

        public WRProductDTO Get(int? id)
        {
            if (id == null)
            {
                throw new Exception("Не установлено id");
            }

            var equipCategory = repository.Get(id.Value);
            if (equipCategory == null)
                throw new Exception("Иноформация не найдена");
            return mapper.Map<WRProductDTO>(repository.Get(id.Value));
        }

        public IEnumerable<WRProductDTO> FindBy(Expression<Func<WRProductDTO, bool>> predicate)
        {
            Expression<Func<WRProduct, bool>> expr = mapper.Map<Expression<Func<WRProductDTO, bool>>, Expression<Func<WRProduct, bool>>>(predicate);
            return repository.FindBy(expr).Select(a => mapper.Map<WRProductDTO>(a));
        }

        public void AddOrUpdate(WRProductDTO obj)
        {
            repository.AddOrUpdate(mapper.Map<WRProduct>(obj));
        }

        public void Delete(WRProductDTO obj)
        {
            repository.Delete(mapper.Map<WRProduct>(obj));
        }
    }
}
