﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Context;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(LibrosContext))]
    partial class LibrosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entitis.Autores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AutoresHasLibrosautorId")
                        .HasColumnType("int");

                    b.Property<int?>("AutoresHasLibroslibro_ISBN")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AutoresHasLibrosautorId", "AutoresHasLibroslibro_ISBN");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("Domain.Entitis.AutoresHasLibros", b =>
                {
                    b.Property<int>("autorId")
                        .HasColumnType("int");

                    b.Property<int>("libro_ISBN")
                        .HasColumnType("int");

                    b.HasKey("autorId", "libro_ISBN");

                    b.HasIndex("libro_ISBN");

                    b.ToTable("AutoresHasLibros");
                });

            modelBuilder.Entity("Domain.Entitis.Editoriales", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Seda")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Editoriales");
                });

            modelBuilder.Entity("Domain.Entitis.Libros", b =>
                {
                    b.Property<int>("ISBN")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ISBN"));

                    b.Property<int?>("AutoresHasLibrosautorId")
                        .HasColumnType("int");

                    b.Property<int?>("AutoresHasLibroslibro_ISBN")
                        .HasColumnType("int");

                    b.Property<int>("EditorialId")
                        .HasColumnType("int");

                    b.Property<string>("n_paginas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sinopsis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ISBN");

                    b.HasIndex("EditorialId");

                    b.HasIndex("AutoresHasLibrosautorId", "AutoresHasLibroslibro_ISBN");

                    b.ToTable("Libros");
                });

            modelBuilder.Entity("Domain.Entitis.Autores", b =>
                {
                    b.HasOne("Domain.Entitis.AutoresHasLibros", null)
                        .WithMany("Autores")
                        .HasForeignKey("AutoresHasLibrosautorId", "AutoresHasLibroslibro_ISBN");
                });

            modelBuilder.Entity("Domain.Entitis.AutoresHasLibros", b =>
                {
                    b.HasOne("Domain.Entitis.Autores", null)
                        .WithMany()
                        .HasForeignKey("autorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entitis.Libros", null)
                        .WithMany()
                        .HasForeignKey("libro_ISBN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entitis.Libros", b =>
                {
                    b.HasOne("Domain.Entitis.Editoriales", "Editoriales")
                        .WithMany()
                        .HasForeignKey("EditorialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entitis.AutoresHasLibros", null)
                        .WithMany("Libros")
                        .HasForeignKey("AutoresHasLibrosautorId", "AutoresHasLibroslibro_ISBN");

                    b.Navigation("Editoriales");
                });

            modelBuilder.Entity("Domain.Entitis.AutoresHasLibros", b =>
                {
                    b.Navigation("Autores");

                    b.Navigation("Libros");
                });
#pragma warning restore 612, 618
        }
    }
}