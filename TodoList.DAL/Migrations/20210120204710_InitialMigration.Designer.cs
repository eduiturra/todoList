﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoList.DAL;

namespace TodoList.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210120204710_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10");

            modelBuilder.Entity("TodoList.DAL.Models.Tareas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Estado")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Username");

                    b.ToTable("Tareas");
                });

            modelBuilder.Entity("TodoList.DAL.Models.Usuarios", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.HasKey("Username");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("TodoList.DAL.Models.Tareas", b =>
                {
                    b.HasOne("TodoList.DAL.Models.Usuarios", "Usuarios")
                        .WithMany("Tareas")
                        .HasForeignKey("Username");
                });
#pragma warning restore 612, 618
        }
    }
}
