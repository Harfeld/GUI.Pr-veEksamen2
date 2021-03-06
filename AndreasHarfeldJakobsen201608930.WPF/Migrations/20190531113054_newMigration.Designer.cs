﻿// <auto-generated />
using System;
using AndreasHarfeldJakobsen201608930.WPF.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AndreasHarfeldJakobsen201608930.WPF.Migrations
{
    [DbContext(typeof(BereauDbContext))]
    [Migration("20190531113054_newMigration")]
    partial class newMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AndreasHarfeldJakobsen201608930.WPF.Models.Assignment", b =>
                {
                    b.Property<int>("AssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .IsRequired();

                    b.Property<string>("Costumer")
                        .IsRequired();

                    b.Property<int>("Duration");

                    b.Property<string>("Location")
                        .IsRequired();

                    b.Property<int>("ModelsNeeded");

                    b.Property<bool>("Planned");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("AssignmentId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("AndreasHarfeldJakobsen201608930.WPF.Models.Model", b =>
                {
                    b.Property<int>("ModelId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Comment")
                        .IsRequired();

                    b.Property<string>("HairColor")
                        .IsRequired();

                    b.Property<int>("Height");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Phone")
                        .HasMaxLength(11);

                    b.Property<int>("Weight");

                    b.HasKey("ModelId");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("AndreasHarfeldJakobsen201608930.WPF.Models.ModelAssignment", b =>
                {
                    b.Property<int>("AssignmentId");

                    b.Property<int>("ModelId");

                    b.HasKey("AssignmentId", "ModelId");

                    b.HasIndex("ModelId");

                    b.ToTable("ModelAssignments");
                });

            modelBuilder.Entity("AndreasHarfeldJakobsen201608930.WPF.Models.ModelAssignment", b =>
                {
                    b.HasOne("AndreasHarfeldJakobsen201608930.WPF.Models.Assignment", "Assignment")
                        .WithMany("ModelAssignments")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AndreasHarfeldJakobsen201608930.WPF.Models.Model", "Model")
                        .WithMany("ModelAssignments")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
