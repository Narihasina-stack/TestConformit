using AutoMapper;
using TestProgrammationConformit.Datas.Dtos;

namespace TestProgrammationConformit.Profiles
{
    public class PersonneProfile : Profile
    {
        public PersonneProfile()
        {
            CreateMap<Datas.Entity.Personne, PersonneDto>();
            CreateMap<PersonneDto, Datas.Entity.Personne>();
        }
    }
}
