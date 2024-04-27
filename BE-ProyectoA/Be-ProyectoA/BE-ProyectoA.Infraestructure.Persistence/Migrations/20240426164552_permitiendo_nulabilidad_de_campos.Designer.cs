﻿// <auto-generated />
using System;
using BE_ProyectoA.Infraestructure.Persistence.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BE_ProyectoA.Infraestructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240426164552_permitiendo_nulabilidad_de_campos")]
    partial class permitiendo_nulabilidad_de_campos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral.CoordinadoresGenerales", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("CantidadVotantes")
                        .HasColumnType("int");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NumeroTelefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("CoordinadoresGenerales");
                });

            modelBuilder.Entity("BE_ProyectoA.Core.Domain.Entities.Coordinadores.SubCoordinadores", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CantidadVotantes")
                        .HasColumnType("int");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<Guid>("CoordinadorsGeneralesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NumeroTelefono")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("CoordinadorsGeneralesId");

                    b.ToTable("SubCoordinadores");
                });

            modelBuilder.Entity("BE_ProyectoA.Core.Domain.Entities.Director.Directores", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CantidadVotantes")
                        .HasColumnType("int");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NumeroTelefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Directores");
                });

            modelBuilder.Entity("BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador.DirigentesMultiplicadores", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CantidadVotantes")
                        .HasColumnType("int");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NumeroTelefono")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<Guid>("SubCoordinadoresId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SubCoordinadoresId");

                    b.ToTable("DirigentesMultiplicadores");
                });

            modelBuilder.Entity("BE_ProyectoA.Core.Domain.Entities.GruposEntity.GrupoDirigente.GrupoDirigente", b =>
                {
                    b.Property<Guid>("GrupoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DirigenteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GrupoId", "DirigenteId");

                    b.HasIndex("DirigenteId");

                    b.ToTable("GrupoDirigente");
                });

            modelBuilder.Entity("BE_ProyectoA.Core.Domain.Entities.GruposEntity.GrupoSubCoordinador.GrupoSubCoordinador", b =>
                {
                    b.Property<Guid>("GrupoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubCoordinadorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GrupoId", "SubCoordinadorId");

                    b.HasIndex("SubCoordinadorId");

                    b.ToTable("GrupoSubCoordinador");
                });

            modelBuilder.Entity("BE_ProyectoA.Core.Domain.Entities.GruposEntity.Grupos", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<Guid>("CoordinadoresGeneralesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NombreGrupo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CoordinadoresGeneralesId");

                    b.ToTable("Grupos");
                });

            modelBuilder.Entity("BE_ProyectoA.Core.Domain.Entities.Votantes.Votante", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<Guid?>("CoordinadorGeneralId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DirectorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DirigenteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NumeroTelefono")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<Guid?>("SubCoordinadorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CoordinadorGeneralId");

                    b.HasIndex("DirectorId");

                    b.HasIndex("DirigenteId");

                    b.HasIndex("SubCoordinadorId");

                    b.ToTable("Votantes");
                });

            modelBuilder.Entity("BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral.CoordinadoresGenerales", b =>
                {
                    b.OwnsOne("BE_ProyectoA.Core.Domain.ValueObjects.Direccion", "Direccion", b1 =>
                        {
                            b1.Property<Guid>("CoordinadoresGeneralesId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("CasaElectoral")
                                .HasColumnType("int");

                            b1.Property<string>("Provincia")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("nvarchar(30)");

                            b1.Property<string>("Sector")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("nvarchar(30)");

                            b1.HasKey("CoordinadoresGeneralesId");

                            b1.ToTable("CoordinadoresGenerales");

                            b1.WithOwner()
                                .HasForeignKey("CoordinadoresGeneralesId");
                        });

                    b.Navigation("Direccion")
                        .IsRequired();
                });

            modelBuilder.Entity("BE_ProyectoA.Core.Domain.Entities.Coordinadores.SubCoordinadores", b =>
                {
                    b.HasOne("BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral.CoordinadoresGenerales", "Coordinadores")
                        .WithMany("SubCoordinadores")
                        .HasForeignKey("CoordinadorsGeneralesId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.OwnsOne("BE_ProyectoA.Core.Domain.ValueObjects.Direccion", "Direccion", b1 =>
                        {
                            b1.Property<Guid>("SubCoordinadoresId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("CasaElectoral")
                                .HasColumnType("int");

                            b1.Property<string>("Provincia")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("Sector")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.HasKey("SubCoordinadoresId");

                            b1.ToTable("SubCoordinadores");

                            b1.WithOwner()
                                .HasForeignKey("SubCoordinadoresId");
                        });

                    b.Navigation("Coordinadores");

                    b.Navigation("Direccion")
                        .IsRequired();
                });

            modelBuilder.Entity("BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador.DirigentesMultiplicadores", b =>
                {
                    b.HasOne("BE_ProyectoA.Core.Domain.Entities.Coordinadores.SubCoordinadores", "SubCoordinadores")
                        .WithMany("DirigentesMultiplicadores")
                        .HasForeignKey("SubCoordinadoresId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.OwnsOne("BE_ProyectoA.Core.Domain.ValueObjects.Direccion", "Direccion", b1 =>
                        {
                            b1.Property<Guid>("DirigentesMultiplicadoresId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("CasaElectoral")
                                .HasColumnType("int");

                            b1.Property<string>("Provincia")
                                .IsRequired()
                                .HasMaxLength(40)
                                .HasColumnType("nvarchar(40)");

                            b1.Property<string>("Sector")
                                .IsRequired()
                                .HasMaxLength(40)
                                .HasColumnType("nvarchar(40)");

                            b1.HasKey("DirigentesMultiplicadoresId");

                            b1.ToTable("DirigentesMultiplicadores");

                            b1.WithOwner()
                                .HasForeignKey("DirigentesMultiplicadoresId");
                        });

                    b.Navigation("Direccion")
                        .IsRequired();

                    b.Navigation("SubCoordinadores");
                });

            modelBuilder.Entity("BE_ProyectoA.Core.Domain.Entities.GruposEntity.GrupoDirigente.GrupoDirigente", b =>
                {
                    b.HasOne("BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador.DirigentesMultiplicadores", "Dirigente")
                        .WithMany()
                        .HasForeignKey("DirigenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BE_ProyectoA.Core.Domain.Entities.GruposEntity.Grupos", "Grupo")
                        .WithMany()
                        .HasForeignKey("GrupoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dirigente");

                    b.Navigation("Grupo");
                });

            modelBuilder.Entity("BE_ProyectoA.Core.Domain.Entities.GruposEntity.GrupoSubCoordinador.GrupoSubCoordinador", b =>
                {
                    b.HasOne("BE_ProyectoA.Core.Domain.Entities.GruposEntity.Grupos", "Grupo")
                        .WithMany()
                        .HasForeignKey("GrupoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BE_ProyectoA.Core.Domain.Entities.Coordinadores.SubCoordinadores", "SubCoordinador")
                        .WithMany()
                        .HasForeignKey("SubCoordinadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grupo");

                    b.Navigation("SubCoordinador");
                });

            modelBuilder.Entity("BE_ProyectoA.Core.Domain.Entities.GruposEntity.Grupos", b =>
                {
                    b.HasOne("BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral.CoordinadoresGenerales", "CoordinadorGeneral")
                        .WithMany("Grupos")
                        .HasForeignKey("CoordinadoresGeneralesId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CoordinadorGeneral");
                });

            modelBuilder.Entity("BE_ProyectoA.Core.Domain.Entities.Votantes.Votante", b =>
                {
                    b.HasOne("BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral.CoordinadoresGenerales", "CoordinadorGeneral")
                        .WithMany("Votantes")
                        .HasForeignKey("CoordinadorGeneralId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BE_ProyectoA.Core.Domain.Entities.Director.Directores", "Director")
                        .WithMany("Votantes")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador.DirigentesMultiplicadores", "Dirigente")
                        .WithMany("Votantes")
                        .HasForeignKey("DirigenteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BE_ProyectoA.Core.Domain.Entities.Coordinadores.SubCoordinadores", "SubCoordinador")
                        .WithMany("Votantes")
                        .HasForeignKey("SubCoordinadorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.OwnsOne("BE_ProyectoA.Core.Domain.ValueObjects.Direccion", "Direccion", b1 =>
                        {
                            b1.Property<Guid>("VotanteId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("CasaElectoral")
                                .HasColumnType("int");

                            b1.Property<string>("Provincia")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("Sector")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.HasKey("VotanteId");

                            b1.ToTable("Votantes");

                            b1.WithOwner()
                                .HasForeignKey("VotanteId");
                        });

                    b.Navigation("CoordinadorGeneral");

                    b.Navigation("Direccion")
                        .IsRequired();

                    b.Navigation("Director");

                    b.Navigation("Dirigente");

                    b.Navigation("SubCoordinador");
                });

            modelBuilder.Entity("BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral.CoordinadoresGenerales", b =>
                {
                    b.Navigation("Grupos");

                    b.Navigation("SubCoordinadores");

                    b.Navigation("Votantes");
                });

            modelBuilder.Entity("BE_ProyectoA.Core.Domain.Entities.Coordinadores.SubCoordinadores", b =>
                {
                    b.Navigation("DirigentesMultiplicadores");

                    b.Navigation("Votantes");
                });

            modelBuilder.Entity("BE_ProyectoA.Core.Domain.Entities.Director.Directores", b =>
                {
                    b.Navigation("Votantes");
                });

            modelBuilder.Entity("BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador.DirigentesMultiplicadores", b =>
                {
                    b.Navigation("Votantes");
                });
#pragma warning restore 612, 618
        }
    }
}
