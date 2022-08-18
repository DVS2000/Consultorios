﻿// <auto-generated />
using System;
using Consultorios.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Consultorios.Migrations
{
    [DbContext(typeof(ConsultoriosContext))]
    partial class ConsultoriosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Consultorios.Models.Entities.Agendamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime>("Horario")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("horario");

                    b.Property<int>("Idade")
                        .HasColumnType("integer");

                    b.Property<string>("NomePaciente")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nome_paciente");

                    b.HasKey("Id");

                    b.ToTable("tb_agendamento");
                });
#pragma warning restore 612, 618
        }
    }
}
