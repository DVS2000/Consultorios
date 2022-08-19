using Consultorios.Context;
using Consultorios.Models.Dto;
using Consultorios.Models.Entities;
using Consultorios.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorios.Repository
{
    public class PacienteRepository : BaseRepository, IPacienteRepository
    {
        private readonly ConsultoriosContext _context;

        public PacienteRepository(ConsultoriosContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PacienteDto>> GetPacientesAsync()
        {
            return await _context.Pacientes
                         .Select(x => new PacienteDto { Id = x.Id, Nome = x.Nome})
                         .ToListAsync();
        }

        public async Task<Paciente> GetByIdAsync(int id)
        {
            return await _context.Pacientes
                         .Include(x => x.Consultas)
                         .ThenInclude(c => c.Especialidade)
                         .ThenInclude(c => c.Profissionais)
                         .Where(x => x.Id == id)
                         .FirstOrDefaultAsync();
        }
    }
}
