using Consultorios.Models.Entities;
using System.Collections.Generic;

namespace Consultorios.Models.Dto
{
    public class PacienteDetalhesDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public List<ConsultaDto> Consultas { get; set; }
    }
}
