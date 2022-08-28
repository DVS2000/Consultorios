using Consultorios.Context;
using Consultorios.Models.Dto;
using Consultorios.Models.Entities;
using Consultorios.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorios.Repository
{
    public class ConsultaRepository : BaseRepository, IConsultaRepository
    {
        private readonly ConsultoriosContext _context;

        public ConsultaRepository(ConsultoriosContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Consulta>> GetConsultas(ConsultaParams paramentros)
        {
            var consultas = _context.Consultas
                .Include(x => x.Paciente)
                .Include(x => x.Profissional)
                .Include(x => x.Especialidade).AsQueryable();

            DateTime dataVazia = new DateTime(); 

            if(paramentros.DataInicio != dataVazia) consultas = consultas.Where(x => x.DataHorario >= paramentros.DataInicio);

            if (paramentros.DataFim != dataVazia) consultas = consultas.Where(x => x.DataHorario <= paramentros.DataFim);

            if(!string.IsNullOrEmpty(paramentros.NomeEspecialidade))
            {
                string nomeEspecialidade = paramentros.NomeEspecialidade.ToLower().Trim();
                consultas = consultas.Where(x => x.Especialidade.Nome.ToLower().Contains(nomeEspecialidade));
            }

            return await consultas.ToListAsync();
        }

        public async Task<Consulta> GetConsultaById(int id)
        {
            return await _context.Consultas
                .Where(x => x.Id == id)
                .Include(x => x.Paciente)
                .Include(x => x.Profissional)
                .Include(x => x.Especialidade)
                .FirstOrDefaultAsync();
        }
    }
}
