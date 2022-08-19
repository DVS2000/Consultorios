using Consultorios.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Consultorios.Context
{
    public class ConsultoriosContext : DbContext
    {
        public ConsultoriosContext(DbContextOptions<ConsultoriosContext> options): base(options)
        {

        }

        public DbSet<Consulta> Consultas { get; set; }

        public DbSet<Especialidade> Especialidades { get; set; }

        public DbSet<Paciente> Pacientes { get; set; }

        public DbSet<Profissional> Profissionais { get; set; }

        public DbSet<ProfissionalEspecialidade> ProfissionalEspecialidades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);   
        }
    }
}
