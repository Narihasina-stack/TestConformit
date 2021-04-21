
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TestProgrammationConformit.Datas.Params;
using TestProgrammationConformit.Repositories.Evenement;
using LinqKit;
using AutoMapper;
using TestProgrammationConformit.Datas.Dtos;
using System.Linq;

namespace TestProgrammationConformit.Commons.Service.Evenement
{
    public class EvenementService : IEvenementService
    {
        public IEvenementRepository EvenementRepository { get; set; }
        private readonly IMapper _mapper;

        public EvenementService(IEvenementRepository evenementRepository, IMapper mapper)
        {
            EvenementRepository = evenementRepository;
            _mapper = mapper;
        }
        public void Add(EvenementDto evenementDto)
        {

            EvenementRepository.Add(_mapper.Map<Datas.Entity.Evenement>(evenementDto));
        }

        public void Delete(int id)
        {
            var evenement = EvenementRepository.GetById(id);
            EvenementRepository.Delete(evenement);
        }




        public IEnumerable<EvenementDto> GetAll(EvenementParams param)
        {
            Expression<Func<Datas.Entity.Evenement, bool>> predicate = null;

            if (param.Id.HasValue)
            {
                predicate = p => p.Id == param.Id;
            }

            if (!String.IsNullOrEmpty(param.Titre))
            {
                predicate = predicate.And(p => p.Titre == param.Titre);
            }

            if (param.PersonneId.HasValue)
            {
                predicate = predicate.And(p => p.PersonneId == param.PersonneId);
            }

            var evenements = EvenementRepository.FindAll(predicate).ToList();

            if (evenements.Count() == 0) return null;
            var evenementDtos = _mapper.Map<List<EvenementDto>>(evenements);

            return evenementDtos;
        }

        public EvenementDto GetById(int id)
        {
            var evenement = EvenementRepository.GetById(id);
            return (evenement != null ? _mapper.Map<EvenementDto>(evenement) : null);
        }


        public IEnumerable<EvenementDto> GetAllWithPagination(EvenementParams param, string sortField = "Id",
            int page = 1, int rowPerPage = 10, bool orderAsc = true)
        {
            Expression<Func<Datas.Entity.Evenement, bool>> predicate = p => true;


            if (param.Id.HasValue)
            {
                predicate = p => p.Id == param.Id;
            }

            if (!String.IsNullOrEmpty(param.Titre))
            {
                predicate = predicate.And(p => p.Titre == param.Titre);
            }

            if (param.PersonneId.HasValue)
            {
                predicate = predicate.And(p => p.PersonneId == param.PersonneId);
            }

            var evenements= EvenementRepository.FindAllWithPagination(sortField, predicate, page, rowPerPage, orderAsc).ToList();
            return (evenements.Count() > 0 ? _mapper.Map<List<EvenementDto>>(evenements) : new List<EvenementDto>());
        }


        public void Update(EvenementDto evenementDto)
        {
            EvenementRepository.Update(_mapper.Map<Datas.Entity.Evenement>(evenementDto));
        }
    }
}

