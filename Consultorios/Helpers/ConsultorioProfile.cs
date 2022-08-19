using AutoMapper;
using Consultorios.Models.Dto;
using Consultorios.Models.Entities;

namespace Consultorios.Helpers
{
    public class ConsultorioProfile : Profile
    {
        public ConsultorioProfile()
        {
            CreateMap<Paciente, PacienteDetalhesDto>();
            CreateMap<Consulta, ConsultaDto>()
                .ForMember(dest => dest.Especialidade, opt => opt.MapFrom(src => src.Especialidade.Nome))
                .ForMember(dest => dest.Profissional, opt => opt.MapFrom(src => src.Profissional.Nome));


            CreateMap<PacienteAdicionarDto, Paciente>();
            CreateMap<PacienteAtualizarDto, Paciente>()
                    .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
