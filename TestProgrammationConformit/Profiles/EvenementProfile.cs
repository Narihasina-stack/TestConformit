using AutoMapper;
using TestProgrammationConformit.Datas.Dtos;

namespace TestProgrammationConformit.Profiles
{
    public class EvenementProfile : Profile
    {
        public EvenementProfile()
        {
            CreateMap<Datas.Entity.Evenement, EvenementDto>().ForMember(dest => dest.CommentaireList, opt => opt.MapFrom(src => src.Commentaires));
            CreateMap<EvenementDto, Datas.Entity.Evenement>().ForMember(dest => dest.Commentaires, opt => opt.MapFrom(src => src.CommentaireList));
        }
    }
}
