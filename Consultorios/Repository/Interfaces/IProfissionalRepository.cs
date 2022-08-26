﻿using Consultorios.Models.Dto;
using Consultorios.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consultorios.Repository.Interfaces
{
    public interface IProfissionalRepository : IBaseRepository
    {
        Task<IEnumerable<ProfissionalDto>> GetProfissionais();
        Task<Profissional> GetProfissionalById(int id);
        Task<ProfissionalEspecialidade> GetProfissionalEspecialidade(int profissionalId, int especialidadeId);
    }


}
