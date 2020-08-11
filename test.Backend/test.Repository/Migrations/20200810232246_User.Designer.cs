﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using test.Repository;

namespace test.Repository.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200810232246_User")]
    partial class User
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("test.Repository.Entities.ClientEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Identification")
                        .IsRequired()
                        .HasMaxLength(12);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Identification")
                        .IsUnique();

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("test.Repository.Entities.CoverageEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Description")
                        .IsUnique();

                    b.ToTable("Coverages");
                });

            modelBuilder.Entity("test.Repository.Entities.EntityHelper.ResultEntityHelper", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ErrorMessage");

                    b.HasKey("Id");

                    b.ToTable("ResultEntityHelpers");
                });

            modelBuilder.Entity("test.Repository.Entities.PolicyDetailEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CoverageId");

                    b.Property<decimal>("CoveragePercentage")
                        .HasColumnType("decimal(5,2)");

                    b.Property<int>("PolicyId");

                    b.HasKey("Id");

                    b.HasIndex("CoverageId");

                    b.HasIndex("PolicyId");

                    b.ToTable("PolicyDetails");
                });

            modelBuilder.Entity("test.Repository.Entities.PolicyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("Period");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(16,2)");

                    b.Property<int>("RiskType");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("State");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Policies");
                });

            modelBuilder.Entity("test.Repository.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("UserLogin")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("UserLogin")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("test.Repository.Entities.PolicyDetailEntity", b =>
                {
                    b.HasOne("test.Repository.Entities.CoverageEntity", "Coverage")
                        .WithMany("PolicyDetails")
                        .HasForeignKey("CoverageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("test.Repository.Entities.PolicyEntity", "Policy")
                        .WithMany("PolicyDetails")
                        .HasForeignKey("PolicyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("test.Repository.Entities.PolicyEntity", b =>
                {
                    b.HasOne("test.Repository.Entities.ClientEntity", "Client")
                        .WithMany("Policies")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
