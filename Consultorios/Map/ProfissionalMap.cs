using Consultorios.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultorios.Map
{
    public class ProfissionalMap : BaseMap<Profissional>
    {
        public ProfissionalMap() : base("tb_profissional")
        {
        }

        public override void Configure(EntityTypeBuilder<Profissional> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Nome).HasColumnName("nome").HasColumnType("varchar(100)");
            builder.Property(x => x.Ativo).HasColumnName("activo");

            builder.HasMany(x => x.Especialidades)
                   .WithMany(x => x.Profissionais)
                   .UsingEntity<ProfissionalEspecialidade>(

                       x => x.HasOne(p => p.Especialidade).WithMany().HasForeignKey(x => x.EspecialidadeId),
                       x => x.HasOne(e => e.Profissionais).WithMany().HasForeignKey(x => x.ProfissionalId),

                       x =>
                       {
                           x.ToTable("tb_profissional_especialidade");
                           x.HasKey(p => new { p.ProfissionalId, p.EspecialidadeId });

                           x.Property(p => p.EspecialidadeId).HasColumnName("id_especialidade").IsRequired();
                           x.Property(p => p.ProfissionalId).HasColumnName("id_profissional").IsRequired();
                       }
                   );
        }
    }
}
