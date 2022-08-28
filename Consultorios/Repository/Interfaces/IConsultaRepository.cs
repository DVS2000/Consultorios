using Consultorios.Models.Dto;
using Consultorios.Models.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consultorios.Repository.Interfaces
{
    public interface IConsultaRepository : IBaseRepository
    {
        Task<IEnumerable<Consulta>> GetConsultas(ConsultaParams paramentros);
        Task<Consulta> GetConsultaById(int id);
    }
}
