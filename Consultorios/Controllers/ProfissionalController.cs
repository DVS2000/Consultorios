using AutoMapper;
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

        [HttpPost("adicionar-profissional")]
        public async Task<IActionResult> PostProfissionalEspecialidade(ProfissionalEspecialidadeAdicionarDto profissional)
        {
            int profissionalId = profissional.ProfissionalId;
            int especialidadeId = profissional.EspecialidadeId;

            if (profissionalId <= 0 || especialidadeId <= 0) return BadRequest("Dados invalidos");

            var profissionalEspecialidade =  await _repository.GetProfissionalEspecialidade(profissionalId, especialidadeId);

            if (profissionalEspecialidade != null) return Ok("Especialidade ja cadastrada");

            var especialidadeAdicionar = new ProfissionalEspecialidade
            {
                ProfissionalId = profissionalId,
                EspecialidadeId = especialidadeId
            };

            _repository.Add(especialidadeAdicionar);

            return await _repository.SaveChangesAsync() ? Ok("Especialidade adicionada") : BadRequest("Erro ao adicionar a especialidade");

        }

        [HttpDelete("{profissionalId}/deletar-especialidade/{especialidadeId}")]
        public async Task<IActionResult> DeleteProfissionalEspecialidade(int profissionalId, int especialidadeId)
        {
            if (profissionalId <= 0 || especialidadeId <= 0) return BadRequest("Dados invalidos");

            var profissionalEspecialidade = await _repository.GetProfissionalEspecialidade(profissionalId, especialidadeId);

            if (profissionalEspecialidade == null) return BadRequest("Especialidade nao cadastrada");

            _repository.Delete(profissionalEspecialidade);

            return await _repository.SaveChangesAsync() ? Ok("Especialidade eliminada do profissional") : BadRequest("Erro ao eliminar a especialidade do profissional");
        }
    }
}
