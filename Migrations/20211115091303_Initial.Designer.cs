﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WowRoads.Data;

#nullable disable

namespace IS.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211115091303_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WowRoads.Models.Agent", b =>
                {
                    b.Property<int>("AgentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AgentID"), 1L, 1);

                    b.Property<string>("AgentFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AgentLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.HasKey("AgentID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Agent");
                });

            modelBuilder.Entity("WowRoads.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"), 1L, 1);

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("WowRoads.Models.Guide", b =>
                {
                    b.Property<int>("GuideID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GuideID"), 1L, 1);

                    b.Property<string>("FirstNameGuide")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastNameGuide")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GuideID");

                    b.ToTable("Guide");
                });

            modelBuilder.Entity("WowRoads.Models.Hotel", b =>
                {
                    b.Property<int>("HotelID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Stars")
                        .HasColumnType("int");

                    b.HasKey("HotelID");

                    b.ToTable("Hotel");
                });

            modelBuilder.Entity("WowRoads.Models.Place", b =>
                {
                    b.Property<int>("PlaceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaceID"), 1L, 1);

                    b.Property<int>("AgentID")
                        .HasColumnType("int");

                    b.Property<int>("GuideID")
                        .HasColumnType("int");

                    b.Property<int>("HotelID")
                        .HasColumnType("int");

                    b.Property<string>("PlaceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehicleID")
                        .HasColumnType("int");

                    b.HasKey("PlaceID");

                    b.HasIndex("AgentID");

                    b.HasIndex("GuideID");

                    b.HasIndex("HotelID");

                    b.HasIndex("VehicleID");

                    b.ToTable("Place");
                });

            modelBuilder.Entity("WowRoads.Models.Vehicle", b =>
                {
                    b.Property<int>("VehicleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehicleID"), 1L, 1);

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<string>("VehicleBrand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehicleYear")
                        .HasColumnType("int");

                    b.HasKey("VehicleID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("WowRoads.Models.Agent", b =>
                {
                    b.HasOne("WowRoads.Models.Customer", "Customer")
                        .WithMany("Agent")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("WowRoads.Models.Place", b =>
                {
                    b.HasOne("WowRoads.Models.Agent", "Agent")
                        .WithMany("Place")
                        .HasForeignKey("AgentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WowRoads.Models.Guide", "Guide")
                        .WithMany("Place")
                        .HasForeignKey("GuideID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WowRoads.Models.Hotel", "Hotel")
                        .WithMany("Place")
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WowRoads.Models.Vehicle", "Vehicle")
                        .WithMany("Place")
                        .HasForeignKey("VehicleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");

                    b.Navigation("Guide");

                    b.Navigation("Hotel");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("WowRoads.Models.Vehicle", b =>
                {
                    b.HasOne("WowRoads.Models.Customer", "Customer")
                        .WithMany("Vehicle")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("WowRoads.Models.Agent", b =>
                {
                    b.Navigation("Place");
                });

            modelBuilder.Entity("WowRoads.Models.Customer", b =>
                {
                    b.Navigation("Agent");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("WowRoads.Models.Guide", b =>
                {
                    b.Navigation("Place");
                });

            modelBuilder.Entity("WowRoads.Models.Hotel", b =>
                {
                    b.Navigation("Place");
                });

            modelBuilder.Entity("WowRoads.Models.Vehicle", b =>
                {
                    b.Navigation("Place");
                });
#pragma warning restore 612, 618
        }
    }
}