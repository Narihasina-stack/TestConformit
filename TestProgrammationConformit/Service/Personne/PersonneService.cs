
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using LinqKit;
using TestProgrammationConformit.Datas.Params;
using TestProgrammationConformit.Repositories.Personne;
using AutoMapper;
using TestProgrammationConformit.Datas.Dtos;
using System.Linq;

namespace TestProgrammationConformit.Commons.Service.Personne
{
    public class PersonneService : IPersonneService
    {
        public IPersonneRepository PersonneRepository { get; set; }
        private readonly IMapper _mapper;

        public PersonneService(IPersonneRepository personneRepository, IMapper mapper) 
        {
            PersonneRepository = personneRepository;
            _mapper = mapper;
        }
        public void Add(PersonneDto personneDto)
        {
            PersonneRepository.Add(_mapper.Map<Datas.Entity.Personne>(personneDto));
        }

        public void Delete(int id)
        {
            var personne = PersonneRepository.GetById(id);
            PersonneRepository.Delete(personne);
        }




        public IEnumerable<PersonneDto> GetAll(PersonneParams param)
        {
            Expression<Func<Datas.Entity.Personne, bool>> predicate = null;

            if (param.Id.HasValue)
            {
                predicate = p => p.Id == param.Id;
            }

            if (!String.IsNullOrEmpty(param.Nom))
            {
                predicate = predicate.And(p => p.Nom == param.Nom);
            }

            if (!String.IsNullOrEmpty(param.Prenom))
            {
                predicate = predicate.And(p => p.Prenom == param.Prenom);
            }

            var personnes = PersonneRepository.FindAll(predicate).ToList();
            return (personnes.Count() > 0 ? _mapper.Map<List<PersonneDto>>(personnes) : new List<PersonneDto>());

        }
        
        public PersonneDto GetById(int id)
        {
            var personne = PersonneRepository.GetById(id);
            return (personne != null ? _mapper.Map<PersonneDto>(personne) : null);
        }


        public IEnumerable<PersonneDto> GetAllWithPagination(PersonneParams param, string sortField = "Id",
            int page = 1, int rowPerPage = 10, bool orderAsc = true)
        {
            Expression<Func<Datas.Entity.Personne, bool>> predicate = p => true;

            
            if (param.Id.HasValue)
            {
                predicate = p =>p.Id==param.Id;
            }

            if (!String.IsNullOrEmpty(param.Nom))
            {
                predicate =predicate.And(p => p.Nom == param.Nom);
            }

            if (!String.IsNullOrEmpty(param.Prenom))
            {
                predicate = predicate.And(p => p.Prenom == param.Prenom); 
            }

            var personnes = PersonneRepository.FindAllWithPagination(sortField, predicate, page, rowPerPage, orderAsc).ToList();
            return (personnes.Count() > 0 ? _mapper.Map<List<PersonneDto>>(personnes) : new List<PersonneDto>()); 
        }

        public void Update(PersonneDto personneDto)
        {
            PersonneRepository.Update(_mapper.Map<Datas.Entity.Personne>(personneDto));
        }
    }
}
