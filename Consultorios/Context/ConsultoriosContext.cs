using Consultorios.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Consultorios.Context
{
    public class ConsultoriosContext : DbContext
    {
        public ConsultoriosContext(DbContextOptions<ConsultoriosContext> options): base(options)
        {

        }

        public DbSet<Agendamento> Agendamentos { get; set; }
    }
}
