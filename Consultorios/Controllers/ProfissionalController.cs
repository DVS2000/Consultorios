﻿using AutoMapper;
using Consultorios.Models.Dto;
using Consultorios.Models.Entities;
using Consultorios.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfissionalController : ControllerBase
    {
        private readonly IProfissionalRepository _repository;
        private readonly IMapper _mapper;

        public ProfissionalController(IProfissionalRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var profissionais = await _repository.GetProfissionais();
            return profissionais.Any() ? Ok(profissionais) : NotFound("Profissionais não encontrado");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) return BadRequest("Profissional inválido");

            var profissional = await _repository.GetProfissionalById(id);

            var profissionalRetorno = _mapper.Map<ProfissionalDetalhesDto>(profissional);

            return profissionalRetorno != null ? Ok(profissionalRetorno) : NotFound("Profissional não encontrado");
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProfissionalAdicionarDto profissional)
        {
            if (string.IsNullOrEmpty(profissional.Nome)) return BadRequest("Dados inválidos");

            var profssionalAdicionar = _mapper.Map<Profissional>(profissional);

            _repository.Add(profssionalAdicionar);

            return await _repository.SaveChangesAsync() ? Ok("Profissional adicionado com sucesso") : BadRequest("Erro ao adicionar o profissional");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProfissionalAtualizarDto profissional)
        {
            if (id <= 0) return BadRequest("Profissional inválido");

            var profissionalBanco = await _repository.GetProfissionalById(id);

            if (profissionalBanco == null) return NotFound("Profissional não encontrado na base de dados");

            var profissionalAtualizar = _mapper.Map(profissional, profissionalBanco);

            _repository.Update(profissionalAtualizar);

            return await _repository.SaveChangesAsync() ? Ok("Profissional atualizado com sucesso") : BadRequest("Erro ao atualizar o profissional");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Profissional inválido");

            var profissionalBanco = await _repository.GetProfissionalById(id);

            if (profissionalBanco == null) return NotFound("Profissional não encontrado na base de dados");

            _repository.Delete(profissionalBanco);

            return await _repository.SaveChangesAsync() ? Ok("Profissional eliminado com sucesso") : BadRequest("Erro ao eliminar o profissional");

        }
    }
}
