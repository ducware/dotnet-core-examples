﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("clean")
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Animal.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBird")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Animals", "clean");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 1,
                            CreatedAt = new DateTime(2023, 10, 3, 11, 33, 42, 483, DateTimeKind.Local).AddTicks(8204),
                            Description = "Description #1",
                            IsBird = false,
                            Name = "Animal #1",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Age = 2,
                            CreatedAt = new DateTime(2023, 10, 3, 11, 33, 42, 484, DateTimeKind.Local).AddTicks(8822),
                            Description = "Description #2",
                            IsBird = false,
                            Name = "Animal #2",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Age = 3,
                            CreatedAt = new DateTime(2023, 10, 3, 11, 33, 42, 484, DateTimeKind.Local).AddTicks(8831),
                            Description = "Description #3",
                            IsBird = false,
                            Name = "Animal #3",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Age = 4,
                            CreatedAt = new DateTime(2023, 10, 3, 11, 33, 42, 484, DateTimeKind.Local).AddTicks(8885),
                            Description = "Description #4",
                            IsBird = false,
                            Name = "Animal #4",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            Age = 5,
                            CreatedAt = new DateTime(2023, 10, 3, 11, 33, 42, 484, DateTimeKind.Local).AddTicks(8886),
                            Description = "Description #5",
                            IsBird = false,
                            Name = "Animal #5",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
