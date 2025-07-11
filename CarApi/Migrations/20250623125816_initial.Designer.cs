﻿// <auto-generated />
using CarApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CarApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250623125816_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CarApi.Data.Entities.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CarId"));

                    b.Property<int>("ModelCarModelId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OwnerPersonId")
                        .HasColumnType("integer");

                    b.HasKey("CarId");

                    b.HasIndex("ModelCarModelId");

                    b.HasIndex("OwnerPersonId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarApi.Data.Entities.CarModel", b =>
                {
                    b.Property<int>("CarModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CarModelId"));

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CarModelId");

                    b.ToTable("CarModels");
                });

            modelBuilder.Entity("CarApi.Data.Entities.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PersonId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("CarApi.Data.Entities.Car", b =>
                {
                    b.HasOne("CarApi.Data.Entities.CarModel", "Model")
                        .WithMany()
                        .HasForeignKey("ModelCarModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarApi.Data.Entities.Person", "Owner")
                        .WithMany("cars")
                        .HasForeignKey("OwnerPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("CarApi.Data.Entities.Person", b =>
                {
                    b.Navigation("cars");
                });
#pragma warning restore 612, 618
        }
    }
}
