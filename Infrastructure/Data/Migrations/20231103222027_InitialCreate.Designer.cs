﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(DbfirtsContext))]
    [Migration("20231103222027_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_general_ci")
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("Core.Entities.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("driver", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Name" }, "name")
                        .IsUnique();

                    b.ToTable("team", (string)null);
                });

            modelBuilder.Entity("Teamdriver", b =>
                {
                    b.Property<int>("IdTeam")
                        .HasColumnType("int(11)");

                    b.Property<int>("IdDriver")
                        .HasColumnType("int(11)")
                        .HasColumnName("idDriver");

                    b.HasKey("IdTeam", "IdDriver")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                    b.HasIndex(new[] { "IdDriver" }, "idDriver");

                    b.ToTable("teamdriver", (string)null);
                });

            modelBuilder.Entity("Teamdriver", b =>
                {
                    b.HasOne("Core.Entities.Driver", null)
                        .WithMany()
                        .HasForeignKey("IdDriver")
                        .IsRequired()
                        .HasConstraintName("teamdriver_ibfk_1");

                    b.HasOne("Core.Entities.Team", null)
                        .WithMany()
                        .HasForeignKey("IdTeam")
                        .IsRequired()
                        .HasConstraintName("teamdriver_ibfk_2");
                });
#pragma warning restore 612, 618
        }
    }
}
