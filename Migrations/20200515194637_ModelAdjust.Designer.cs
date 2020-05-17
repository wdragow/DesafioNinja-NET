﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Universidade;

namespace employer_project.Migrations
{
    [DbContext(typeof(UniversidadeContext))]
    [Migration("20200515194637_ModelAdjust")]
    partial class ModelAdjust
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Employer_Project.Models.AlunoModel", b =>
                {
                    b.Property<int>("AlunoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AlunoCPF")
                        .HasColumnType("bigint")
                        .HasMaxLength(11);

                    b.Property<string>("AlunoCurso")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("AlunoNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("AlunoNome")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("AlunoSobrenome")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("AlunoID");

                    b.ToTable("alunos");
                });

            modelBuilder.Entity("Employer_Project.Models.MateriaModel", b =>
                {
                    b.Property<int>("MateriaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("MateriaDataCad")
                        .HasColumnType("datetime2");

                    b.Property<string>("MateriaDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("materiaSitacao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MateriaID");

                    b.ToTable("materias");
                });

            modelBuilder.Entity("Employer_Project.Models.NotasAlunoModel", b =>
                {
                    b.Property<int>("NotaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlunoID")
                        .HasColumnType("int");

                    b.Property<int>("MateriaID")
                        .HasColumnType("int");

                    b.Property<int>("notaMateria")
                        .HasColumnType("int");

                    b.HasKey("NotaID");

                    b.ToTable("notasAluno");
                });
#pragma warning restore 612, 618
        }
    }
}
