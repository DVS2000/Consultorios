using System;

namespace Consultorios.Models.Dto
{
    public class ConsultaDto
    {
        public int Id { get; set; }
        public DateTime DataHorario { get; set; }
        public int Status { get; set; }
        public decimal Preco { get; set; }
        public int PacienteId { get; set; }
        public string Especialidade { get; set; }
        public string Profissional { get; set; }
    }
}
