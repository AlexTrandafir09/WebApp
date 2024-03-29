﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp.Data;

#nullable disable

namespace WebApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240204174824_migrare1")]
    partial class migrare1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApp.Models.Baza_sportiva.Baza_sportiva", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("capacitate")
                        .HasColumnType("int");

                    b.Property<Guid?>("echipa_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("nume_baza")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("echipa_id")
                        .IsUnique()
                        .HasFilter("[echipa_id] IS NOT NULL");

                    b.ToTable("baze_sportive");
                });

            modelBuilder.Entity("WebApp.Models.Echipa.Echipa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("antrenor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("denumire")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("manager")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("valoare")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("echipe");
                });

            modelBuilder.Entity("WebApp.Models.Echipa_liga.Echipa_liga", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("echipa_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("esalon")
                        .HasColumnType("int");

                    b.Property<Guid>("liga_id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("echipa_id");

                    b.HasIndex("liga_id");

                    b.ToTable("echipa_liga");
                });

            modelBuilder.Entity("WebApp.Models.Jucator.Jucator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("data_nasterii")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("echipa_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("numar_tricou")
                        .HasColumnType("int");

                    b.Property<string>("nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prenume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("echipa_id");

                    b.ToTable("jucatori");
                });

            modelBuilder.Entity("WebApp.Models.Liga.Liga", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("denumire")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("esalon")
                        .HasColumnType("int");

                    b.Property<string>("presedinte")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ligi");
                });

            modelBuilder.Entity("WebApp.Models.Baza_sportiva.Baza_sportiva", b =>
                {
                    b.HasOne("WebApp.Models.Echipa.Echipa", "echipa")
                        .WithOne("baza")
                        .HasForeignKey("WebApp.Models.Baza_sportiva.Baza_sportiva", "echipa_id");

                    b.Navigation("echipa");
                });

            modelBuilder.Entity("WebApp.Models.Echipa_liga.Echipa_liga", b =>
                {
                    b.HasOne("WebApp.Models.Liga.Liga", "liga")
                        .WithMany("echipe_ligi")
                        .HasForeignKey("echipa_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp.Models.Echipa.Echipa", "echipa")
                        .WithMany("echipe_ligi")
                        .HasForeignKey("liga_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("echipa");

                    b.Navigation("liga");
                });

            modelBuilder.Entity("WebApp.Models.Jucator.Jucator", b =>
                {
                    b.HasOne("WebApp.Models.Echipa.Echipa", "echipa")
                        .WithMany("jucatori")
                        .HasForeignKey("echipa_id");

                    b.Navigation("echipa");
                });

            modelBuilder.Entity("WebApp.Models.Echipa.Echipa", b =>
                {
                    b.Navigation("baza")
                        .IsRequired();

                    b.Navigation("echipe_ligi");

                    b.Navigation("jucatori");
                });

            modelBuilder.Entity("WebApp.Models.Liga.Liga", b =>
                {
                    b.Navigation("echipe_ligi");
                });
#pragma warning restore 612, 618
        }
    }
}
