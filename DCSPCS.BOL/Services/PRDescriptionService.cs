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
    public class PRDescriptionService : IEntityService<PRDescriptionDTO>
    {
        IGenericRepository<PRDescription> repository;
        readonly IMapper mapper;

        public PRDescriptionService(IGenericRepository<PRDescription> repository)
        {
            this.repository = repository;
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<PRDescription, PRDescriptionDTO>()
                        .ForMember("PRID", opt => opt.MapFrom(c => c.PRID))
                        .ForMember("PRCode", opt => opt.MapFrom(c => c.PRCode))
                        .ForMember("PRName", opt => opt.MapFrom(c => c.PRName));

                cfg.CreateMap<PRDescriptionDTO, PRDescription>();
            }).CreateMapper();
        }

        public IEnumerable<PRDescriptionDTO> GetAll()
        {
            return repository.GetAll().Select(a => mapper.Map<PRDescriptionDTO>(a));
        }

        public PRDescriptionDTO Get(int? id)
        {
            if (id == null)
            {
                throw new Exception("Не установлено id");
            }

            var equipCategory = repository.Get(id.Value);
            if (equipCategory == null)
                throw new Exception("Иноформация не найдена");
            return mapper.Map<PRDescriptionDTO>(repository.Get(id.Value));
        }

        public IEnumerable<PRDescriptionDTO> FindBy(Expression<Func<PRDescriptionDTO, bool>> predicate)
        {
            Expression<Func<PRDescription, bool>> expr = mapper.Map<Expression<Func<PRDescriptionDTO, bool>>, Expression<Func<PRDescription, bool>>>(predicate);
            return repository.FindBy(expr).Select(a => mapper.Map<PRDescriptionDTO>(a));
        }

        public void AddOrUpdate(PRDescriptionDTO obj)
        {
            repository.AddOrUpdate(mapper.Map<PRDescription>(obj));
        }

        public void Delete(PRDescriptionDTO obj)
        {
            repository.Delete(mapper.Map<PRDescription>(obj));
        }
    }
}
