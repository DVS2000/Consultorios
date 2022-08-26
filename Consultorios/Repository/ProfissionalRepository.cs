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
    public class ProfissionalRepository : BaseRepository, IProfissionalRepository
    {
        private readonly ConsultoriosContext _context;

        public ProfissionalRepository(ConsultoriosContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProfissionalDto>> GetProfissionais()
        {
           return await _context.Profissionais
                .Select(x => new ProfissionalDto { Id = x.Id, Nome = x.Nome, Ativo = x.Ativo })
                .ToListAsync();
        }

        public async Task<Profissional> GetProfissionalById(int id)
        {
            return await _context.Profissionais
                  .Include(x => x.Consultas)
                  .Include(x => x.Especialidades)
                  .Where(x => x.Id == id)
                  .FirstOrDefaultAsync();
        }

        public async Task<ProfissionalEspecialidade> GetProfissionalEspecialidade(int profissionalId, int especialidadeId)
        {
            return await _context.ProfissionalEspecialidades
                .Where(x => x.ProfissionalId == profissionalId && x.EspecialidadeId == especialidadeId)
                .FirstOrDefaultAsync();
        }

    }
}
