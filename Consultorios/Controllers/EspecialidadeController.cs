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
    public class EspecialidadeController : ControllerBase
    {
        private readonly IEspecialidadeRepository _repository;
        private readonly IMapper _mapper;

        public EspecialidadeController(IEspecialidadeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var especialidades = await _repository.GetEspecialidades();
            return especialidades.Any() ? Ok(especialidades) : NotFound("Não foi encontrado nenhuma especialidade");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) return BadRequest("Id invalido");

            var especialidade = await _repository.GetEspecialidadeById(id);

            var especialidadeRetorno = _mapper.Map<EspecialidadeDetalhesDto>(especialidade);

            return especialidade != null ? Ok(especialidade) : NotFound("Não foi encontrado nenhuma especialidade");
        }

        [HttpPost]
        public async Task<IActionResult> Post(EspecialidadeAdicionarDto especialidade)
        {
            if (string.IsNullOrEmpty(especialidade.Nome)) return BadRequest("nome invalido");

            var especialidadeAdiciona = new Especialidade
            {
                Nome = especialidade.Nome,
                Ativa = especialidade.Ativa
            };

            _repository.Add(especialidadeAdiciona);

            return await _repository.SaveChangesAsync() ? Ok("Especialidade adiciionada") : BadRequest("Erro ao adicionar especialidade");

        }

        [HttpPut("{id}/atualizar-status/")]
        public async Task<IActionResult> Put(int id, bool ativo)
        {
            if (id <= 0) return BadRequest("Especialidade invalida");

            var especialidade = await _repository.GetEspecialidadeById(id);

            if (especialidade == null) return NotFound("Especialidade nao encontrada na base de dados");

            string status = ativo ? "ativa" : "inativa";
            if (especialidade.Ativa == ativo) return Ok("A especialidade ja esta " + status);

            especialidade.Ativa = ativo;

            _repository.Update(especialidade);

            return await _repository.SaveChangesAsync() ? Ok("Status da Especialidade atualizada") : BadRequest("Erro ao atualizar status da especialidade");

        }
    }
}
