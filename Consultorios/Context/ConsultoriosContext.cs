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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var agendamento = modelBuilder.Entity<Agendamento>();

            agendamento.ToTable("tb_agendamento");
            agendamento.HasKey(x => x.Id);
            agendamento.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            agendamento.Property(x => x.NomePaciente).HasColumnName("nome_paciente").HasColumnType("varchar(100)").IsRequired();
            agendamento.Property(x => x.Horario).IsRequired().HasColumnName("horario");
        }
    }
}
