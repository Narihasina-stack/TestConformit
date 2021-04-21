
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TestProgrammationConformit.Datas.Params;
using TestProgrammationConformit.Repositories.Commentaire;
using LinqKit;
using TestProgrammationConformit.Datas.Dtos;
using AutoMapper;
using System.Linq;

namespace TestProgrammationConformit.Commons.Service.Commentaire
{
    public class CommentaireService : ICommentaireService
    {
        public ICommentaireRepository CommentaireRepository { get; set; }
        private readonly IMapper _mapper;
        public CommentaireService(ICommentaireRepository commentaireRepository, IMapper mapper)
        {
            CommentaireRepository = commentaireRepository;
            _mapper = mapper;
        }
        public void Add(CommentaireDto commentaireDto)
        {
            var commentaire = _mapper.Map<Datas.Entity.Commentaire>(commentaireDto);
            CommentaireRepository.Add(commentaire);
        }

        public void Delete(int id)
        {
            var commentaire = CommentaireRepository.GetById(id);
            CommentaireRepository.Delete(commentaire);
        }




        public IEnumerable<CommentaireDto> GetAll(CommentaireParams param)
        {
            Expression<Func<Datas.Entity.Commentaire, bool>> predicate = null;

            if (param.Id.HasValue)
            {
                predicate = p => p.Id == param.Id;
            }
            
            if (param.EvenementId.HasValue)
            {
                predicate = predicate.And(p => p.EvenementId == param.EvenementId);
            }

            var commentaires = CommentaireRepository.FindAll(predicate).ToList();
            return (commentaires.Count()>0? _mapper.Map<List<CommentaireDto>>(commentaires) : new List<CommentaireDto>());

        }

        public CommentaireDto GetById(int id)
        {
            var commentaire = CommentaireRepository.GetById(id);
            return (commentaire != null ? _mapper.Map<CommentaireDto>(commentaire) : new CommentaireDto());
        }


        public IEnumerable<CommentaireDto> GetAllWithPagination(CommentaireParams param, string sortField = "Id",
            int page = 1, int rowPerPage = 10, bool orderAsc = true)
        {
            Expression<Func<Datas.Entity.Commentaire, bool>> predicate = p => true;


            if (param.Id.HasValue)
            {
                predicate = p => p.Id == param.Id;
            }

           
            if (param.EvenementId.HasValue)
            {
                predicate = predicate.And(p => p.EvenementId == param.EvenementId);
            }

           
            var commentaires = CommentaireRepository.FindAllWithPagination(sortField, predicate, page, rowPerPage, orderAsc).ToList();
            return (commentaires.Count()>0 ? _mapper.Map<List<CommentaireDto>>(commentaires) : new List<CommentaireDto>());
        }

        public void Update(CommentaireDto commentaireDto)
        {
            CommentaireRepository.Update(_mapper.Map<Datas.Entity.Commentaire>(commentaireDto));
        }
    }
}
