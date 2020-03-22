﻿// <auto-generated />
using System;
using Delopgaveprojekt_ITONK_F20_Gruppe3.AppDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Delopgaveprojekt_ITONK_F20_Gruppe3.Migrations
{
    [DbContext(typeof(AppDbContext.AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Delopgaveprojekt_ITONK_F20_Gruppe3.Models.Haandvaerker", b =>
                {
                    b.Property<int>("HaandvaerkerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("HVAnsaettelsedato")
                        .HasColumnType("datetime2");

                    b.Property<string>("HVEfternavn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HVFagomraade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HVFornavn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HaandvaerkerID");

                    b.ToTable("Haandvaerkere");
                });

            modelBuilder.Entity("Delopgaveprojekt_ITONK_F20_Gruppe3.Models.Vaerktoej", b =>
                {
                    b.Property<long>("VTID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("LiggerIvtk")
                        .HasColumnType("int");

                    b.Property<DateTime>("VTAnskaffet")
                        .HasColumnType("datetime2");

                    b.Property<string>("VTFabrikat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VTModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VTSerienr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VTType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VaerktoejskasseVTKID")
                        .HasColumnType("int");

                    b.HasKey("VTID");

                    b.HasIndex("VaerktoejskasseVTKID");

                    b.ToTable("Vaerktoejer");
                });

            modelBuilder.Entity("Delopgaveprojekt_ITONK_F20_Gruppe3.Models.Vaerktoejskasse", b =>
                {
                    b.Property<int>("VTKID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("HaandvaerkerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("VTKAnskaffet")
                        .HasColumnType("datetime2");

                    b.Property<int?>("VTKEjesAf")
                        .HasColumnType("int");

                    b.Property<string>("VTKFabrikat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VTKFarve")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VTKModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VTKSerienummer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VTKID");

                    b.HasIndex("HaandvaerkerID");

                    b.ToTable("Vaerktoejskasser");
                });

            modelBuilder.Entity("Delopgaveprojekt_ITONK_F20_Gruppe3.Models.Vaerktoej", b =>
                {
                    b.HasOne("Delopgaveprojekt_ITONK_F20_Gruppe3.Models.Vaerktoejskasse", null)
                        .WithMany("Vaerktoej")
                        .HasForeignKey("VaerktoejskasseVTKID");
                });

            modelBuilder.Entity("Delopgaveprojekt_ITONK_F20_Gruppe3.Models.Vaerktoejskasse", b =>
                {
                    b.HasOne("Delopgaveprojekt_ITONK_F20_Gruppe3.Models.Haandvaerker", null)
                        .WithMany("Vaerktoejskasse")
                        .HasForeignKey("HaandvaerkerID");
                });
#pragma warning restore 612, 618
        }
    }
}