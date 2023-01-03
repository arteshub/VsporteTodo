﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VSporte.DataAccessLayer.DbContextBase;

#nullable disable

namespace VSporte.DataAccessLayer.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230103074036_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VSporte.DataAccessLayer.Models.GameEvent", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventId"));

                    b.Property<int>("ClubId")
                        .HasColumnType("int");

                    b.Property<string>("EventType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TimeOfEvent")
                        .HasColumnType("datetime2");

                    b.Property<string>("VsporteDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventId");

                    b.HasIndex("ClubId");

                    b.HasIndex("PlayerId");

                    b.ToTable("GameEvents");
                });

            modelBuilder.Entity("VSporte.Task.Solution.Models.ClubItem", b =>
                {
                    b.Property<int>("ClubId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClubId"));

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VsporteDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClubId");

                    b.ToTable("ClubItems");
                });

            modelBuilder.Entity("VSporte.Task.Solution.Models.PlayerClubItem", b =>
                {
                    b.Property<int>("SystemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SystemId"));

                    b.Property<int>("ClubId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<string>("VsporteDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SystemId");

                    b.HasIndex("ClubId");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerClubItems");
                });

            modelBuilder.Entity("VSporte.Task.Solution.Models.PlayerItem", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayerId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VsporteDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlayerId");

                    b.ToTable("PlayerItems");
                });

            modelBuilder.Entity("VSporte.DataAccessLayer.Models.GameEvent", b =>
                {
                    b.HasOne("VSporte.Task.Solution.Models.ClubItem", "Club")
                        .WithMany("GameEvents")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VSporte.Task.Solution.Models.PlayerItem", "Player")
                        .WithMany("GameEvents")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Club");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("VSporte.Task.Solution.Models.PlayerClubItem", b =>
                {
                    b.HasOne("VSporte.Task.Solution.Models.ClubItem", "Club")
                        .WithMany("PlayerClubItems")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VSporte.Task.Solution.Models.PlayerItem", "Player")
                        .WithMany("PlayerClubItems")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Club");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("VSporte.Task.Solution.Models.ClubItem", b =>
                {
                    b.Navigation("GameEvents");

                    b.Navigation("PlayerClubItems");
                });

            modelBuilder.Entity("VSporte.Task.Solution.Models.PlayerItem", b =>
                {
                    b.Navigation("GameEvents");

                    b.Navigation("PlayerClubItems");
                });
#pragma warning restore 612, 618
        }
    }
}
