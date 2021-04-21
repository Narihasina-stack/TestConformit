using AutoMapper ;
using TestProgrammationConformit.Datas.Dtos;


namespace TestProgrammationConformit.Profiles
{
    public class CommentaireProfile : Profile
    {
        public CommentaireProfile()
        {
            CreateMap<Datas.Entity.Commentaire,CommentaireDto>();
            CreateMap<CommentaireDto, Datas.Entity.Commentaire>();
        }
    }
}
