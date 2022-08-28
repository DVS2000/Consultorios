using AutoMapper;
using Consultorios.Models.Dto;
using Consultorios.Models.Entities;
using Consultorios.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentoController : ControllerBase
    {
        private readonly IConsultaRepository _repository;
        private readonly IMapper _mapper;

        public AgendamentoController(IConsultaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]ConsultaParams parametros) 
        {
            var consultas =  await _repository.GetConsultas(parametros);

            var consultasRetorno = _mapper.Map<IEnumerable<ConsultaDetalhesDto>>(consultas);

            return consultasRetorno.Any() ? Ok(consultasRetorno) : NotFound("Nenhuma consulta encontrada");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) return BadRequest("consulta invalida");
            var consultas = await _repository.GetConsultaById(id);

            var consultaRetorno = _mapper.Map<ConsultaDetalhesDto>(consultas);

            return consultaRetorno != null ? Ok(consultaRetorno) : NotFound("Consulta nao encontrada");
        }

        [HttpPost]
        public async Task<IActionResult> Post(ConsultaAdicionarDto consulta)
        {
            if (consulta == null) return BadRequest("Dados invalidos");

            var consultaAdiciona = _mapper.Map<Consulta>(consulta);

            _repository.Add(consultaAdiciona);

            return await _repository.SaveChangesAsync() ? Ok("Consultas Agendada") : BadRequest("Erro ao agendar consulta");

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ConsultaAtualizarDto consulta)
        {
            if (id <= 0) return BadRequest("consulta invalida");

            var consultaBanco = await _repository.GetConsultaById(id);

            if(consultaBanco == null) return BadRequest("Consulta nao existe na base de dados");

            if (consulta == null) return BadRequest("Dados invalidos");

            if(consulta.DataHorario == new DateTime()) consulta.DataHorario = consultaBanco.DataHorario;

            if (id <= consulta.ProfissionalId) return BadRequest("Profissional invalido");

            var consultaAtualiza = _mapper.Map(consulta, consultaBanco);

            _repository.Update(consultaAtualiza);

            return await _repository.SaveChangesAsync() ? Ok("Agendamento atualizada") : BadRequest("Erro ao atualizar agendamento da consulta");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("consulta invalida");

            var consultaBanco = await _repository.GetConsultaById(id);

            if (consultaBanco == null) return BadRequest("Consulta nao existe na base de dados");

            _repository.Delete(consultaBanco);

            return await _repository.SaveChangesAsync() ? Ok("Agendamento cancelado") : BadRequest("Erro ao cancelar agendamento da consulta");

        }
    }
}
