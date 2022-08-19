using Consultorios.Models.Dto;
using Consultorios.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consultorios.Repository.Interfaces
{
    public interface IPacienteRepository : IBaseRepository
    {
        Task<IEnumerable<PacienteDto>> GetPacientesAsync();

        Task<Paciente> GetByIdAsync(int id);
    }
}
