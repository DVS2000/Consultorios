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
    public class EspecialidadeRepository : BaseRepository, IEspecialidadeRepository
    {
        private readonly ConsultoriosContext _context;

        public EspecialidadeRepository(ConsultoriosContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EspecialidadeDto>> GetEspecialidades()
        {
            return await _context.Especialidades
                .Select(x => new EspecialidadeDto { Id = x.Id, Nome = x.Nome, Ativa = x.Ativa })
                .ToListAsync();
        }

        public async Task<Especialidade> GetEspecialidadeById(int id)
        {
            return await _context.Especialidades
                .Include(x => x.Profissionais)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
