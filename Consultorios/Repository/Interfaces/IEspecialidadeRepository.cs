using Consultorios.Models.Dto;
using Consultorios.Models.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consultorios.Repository.Interfaces
{
    public interface IEspecialidadeRepository : IBaseRepository
    {
        Task<IEnumerable<EspecialidadeDto>> GetEspecialidades();
        Task<Especialidade> GetEspecialidadeById(int id);
    }
}
