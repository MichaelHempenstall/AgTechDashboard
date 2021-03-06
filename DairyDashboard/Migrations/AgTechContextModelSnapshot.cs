﻿// <auto-generated />
using System;
using DairyDashboard;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DairyDashboard.Migrations
{
    [DbContext(typeof(AgTechContext))]
    partial class AgTechContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9");

            modelBuilder.Entity("DairyDashboard.Models.Farm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FarmName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Farms");
                });

            modelBuilder.Entity("DairyDashboard.Models.Machine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("MachineName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("DairyDashboard.Models.MachineData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrentUsage")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FarmId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MachineId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ValueDateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MachineData");
                });

            modelBuilder.Entity("DairyDashboard.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
