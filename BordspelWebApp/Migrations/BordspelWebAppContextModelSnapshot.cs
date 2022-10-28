﻿// <auto-generated />
using System;
using BordspelWebApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BordspelWebApp.Migrations
{
    [DbContext(typeof(BordspelWebAppContext))]
    partial class BordspelWebAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("BordspelWebApp")
                .HasAnnotation("ProductVersion", "3.1.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BordspelWebApp.Models.Bordspel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Afbeelding")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Beschrijving")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Jaar")
                        .HasColumnType("int");

                    b.Property<int?>("Leeftijd")
                        .HasColumnType("int");

                    b.Property<int?>("MaxAantalSpelers")
                        .HasColumnType("int");

                    b.Property<int?>("MaxSpeeltijd")
                        .HasColumnType("int");

                    b.Property<int?>("MinAantalSpelers")
                        .HasColumnType("int");

                    b.Property<int?>("MinSpeeltijd")
                        .HasColumnType("int");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bordspel");
                });

            modelBuilder.Entity("BordspelWebApp.Models.BordspelPersoon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BordspelId")
                        .HasColumnType("int");

                    b.Property<int>("PersoonId")
                        .HasColumnType("int");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BordspelId");

                    b.HasIndex("PersoonId");

                    b.HasIndex("RolId");

                    b.ToTable("BordspelPersoon");
                });

            modelBuilder.Entity("BordspelWebApp.Models.Collectie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BordspelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BordspelId");

                    b.ToTable("Collectie");
                });

            modelBuilder.Entity("BordspelWebApp.Models.Persoon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Beschrijving")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Voornaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persoon");
                });

            modelBuilder.Entity("BordspelWebApp.Models.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Beschrijving")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("BordspelWebApp.Models.Uitgave", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BordspelId")
                        .HasColumnType("int");

                    b.Property<string>("Taal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UitgeverijId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BordspelId");

                    b.HasIndex("UitgeverijId");

                    b.ToTable("Uitgave");
                });

            modelBuilder.Entity("BordspelWebApp.Models.Uitgeverij", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Beschrijving")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Land")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Uitgeverij");
                });

            modelBuilder.Entity("BordspelWebApp.Models.BordspelPersoon", b =>
                {
                    b.HasOne("BordspelWebApp.Models.Bordspel", "Bordspel")
                        .WithMany("BordspelPersonen")
                        .HasForeignKey("BordspelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BordspelWebApp.Models.Persoon", "Persoon")
                        .WithMany("BordspelPersonen")
                        .HasForeignKey("PersoonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BordspelWebApp.Models.Rol", "Rol")
                        .WithMany("BordspelPersonen")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BordspelWebApp.Models.Collectie", b =>
                {
                    b.HasOne("BordspelWebApp.Models.Bordspel", "Bordspel")
                        .WithMany("Collecties")
                        .HasForeignKey("BordspelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BordspelWebApp.Models.Uitgave", b =>
                {
                    b.HasOne("BordspelWebApp.Models.Bordspel", "Bordspel")
                        .WithMany("Uitgaves")
                        .HasForeignKey("BordspelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BordspelWebApp.Models.Uitgeverij", "Uitgeverij")
                        .WithMany("Uitgaves")
                        .HasForeignKey("UitgeverijId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
