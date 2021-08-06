using AutoMapper;
using SmartSchool.WebAPI.V1.Dtos;
using SmartSchool.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartSchool.WebAPI.Helpers;

namespace SmartSchool.WebAPI.V1.Profiles {
    public class SmartSchoolProfile : Profile { // profile do automapper que indica o .........
        public SmartSchoolProfile() {
            CreateMap<Aluno, AlunoDto>() // fala pro automapper que sempre que estiver trabalhando com aluno, quero que meu aluno seja mapeado com meu alunoDto
                .ForMember(
                    dest => dest.Nome, // meu destino nome recebe oq tem embaixo
                    opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}") // cria uma opção de mapeamento no nosso source
                )
                .ForMember( // calcula a idade a partir do ano dado
                    dest => dest.Idade,
                    opt => opt.MapFrom(src => src.DataNasc.GetCurrentAge()) // mapeia a idade
                );

            CreateMap<AlunoDto, Aluno>();
            CreateMap<Aluno, AlunoRegistrarDto>().ReverseMap();
        }
    }
}
