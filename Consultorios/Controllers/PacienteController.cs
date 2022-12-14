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
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepository _repository;
        private readonly IMapper _mapper;

        public PacienteController(IPacienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var pacientes = await _repository.GetPacientesAsync();

            return pacientes.Any() ? Ok(pacientes) : BadRequest("Paciente não encontrado");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var paciente = await _repository.GetByIdAsync(id);

            var pacienteRetorno = _mapper.Map<PacienteDetalhesDto>(paciente);

            return pacienteRetorno != null ? Ok(pacienteRetorno) : BadRequest("Paciente não encontrado");
        }

        [HttpPost]
        public async Task<IActionResult> Post(PacienteAdicionarDto paciente)
        {
            if (paciente == null) return BadRequest("Dados inválidos");

            var pacienteAdicionar = _mapper.Map<Paciente>(paciente);

            _repository.Add(pacienteAdicionar);

            return await _repository.SaveChangesAsync() 
                ? Ok("Paciente adicionado com sucesso") 
                : BadRequest("Erro ao salvar o paciente");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PacienteAtualizarDto paciente)
        {
            if (id <= 0) return BadRequest("Usuário não informado");

            var pacienteBD = await _repository.GetByIdAsync(id);

            if (pacienteBD != null) return NotFound("Paciente não encontrado");

            var pacienteAtualizar = _mapper.Map(paciente, pacienteBD);

            _repository.Update(pacienteAtualizar);

            return await _repository.SaveChangesAsync()
                ? Ok("Paciente atualizado com sucesso")
                : BadRequest("Erro ao atualizar o paciente");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Paciente inválido");

            var pacienteExclui = await _repository.GetByIdAsync(id);

            if (pacienteExclui == null) return NotFound("Paciente não encontrado");

            _repository.Delete(pacienteExclui);

            return await _repository.SaveChangesAsync()
                ? Ok("Paciente deletado com sucesso")
                : BadRequest("Erro ao deletar o paciente");
        }
        
    }
}
