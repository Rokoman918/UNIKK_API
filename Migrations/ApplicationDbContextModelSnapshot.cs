﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UNIKK_API.Contexts;

namespace UNIKK_API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UNIKK_API.Entities.Enterprice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.Property<short>("Tax_Id")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("Enterprices");
                });

            modelBuilder.Entity("UNIKK_API.Entities.Person", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UnityId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UnityId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("UNIKK_API.Entities.PhoneNumber", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PersonId")
                        .HasColumnType("bigint");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("PhoneNumbers");
                });

            modelBuilder.Entity("UNIKK_API.Entities.TypeUnity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypeUnities");
                });

            modelBuilder.Entity("UNIKK_API.Entities.Unity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdEnterprice")
                        .HasColumnType("int");

                    b.Property<int>("IdtypeUnity")
                        .HasColumnType("int");

                    b.Property<int?>("enterpriceNavId")
                        .HasColumnType("int");

                    b.Property<int?>("typeUnityNavId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("enterpriceNavId");

                    b.HasIndex("typeUnityNavId");

                    b.ToTable("Unitys");
                });

            modelBuilder.Entity("UNIKK_API.Entities.Person", b =>
                {
                    b.HasOne("UNIKK_API.Entities.Unity", "IdUnityNav")
                        .WithMany("People")
                        .HasForeignKey("UnityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UNIKK_API.Entities.PhoneNumber", b =>
                {
                    b.HasOne("UNIKK_API.Entities.Person", "PersonNav")
                        .WithMany("Phones")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UNIKK_API.Entities.Unity", b =>
                {
                    b.HasOne("UNIKK_API.Entities.Enterprice", "enterpriceNav")
                        .WithMany("Unities")
                        .HasForeignKey("enterpriceNavId");

                    b.HasOne("UNIKK_API.Entities.TypeUnity", "typeUnityNav")
                        .WithMany("Unities")
                        .HasForeignKey("typeUnityNavId");
                });
#pragma warning restore 612, 618
        }
    }
}