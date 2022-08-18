using Consultorios.Models.Entities;
using System.Collections.Generic;

namespace Consultorios.Models.Entities
{
    public class Paciente : Base
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Cpf { get; set; }
        public List<Consulta> Consultas { get; set; }
    }
}