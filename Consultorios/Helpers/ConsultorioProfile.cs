using AutoMapper;
using Consultorios.Models.Dto;
using Consultorios.Models.Entities;
using System.Linq;

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

            CreateMap<Profissional, ProfissionalDetalhesDto>()
                .ForMember(dest => dest.TotalConsultas, optt => optt.MapFrom(src => src.Consultas.Count))
                .ForMember(
                    dest => dest.Especialidades, 
                    opt => opt.MapFrom(src => src.Especialidades.Select(x => x.Nome).ToArray())
                );

            CreateMap<Profissional, ProfissionalDto>();

            CreateMap<ProfissionalAdicionarDto, Profissional>();
            CreateMap<ProfissionalAtualizarDto, Profissional>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Especialidade, EspecialidadeDetalhesDto>();
        }
    }
}
