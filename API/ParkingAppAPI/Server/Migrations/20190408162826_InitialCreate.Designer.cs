﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Server.Repositories;

namespace Server.Migrations
{
    [DbContext(typeof(ParkingDbContext))]
    [Migration("20190408162826_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity("Server.Models.Car", b =>
                {
                    b.Property<int>("VIN")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PTI");

                    b.Property<int>("UserId");

                    b.HasKey("VIN");

                    b.HasIndex("UserId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Server.Models.ParkingLot", b =>
                {
                    b.Property<int>("ParkingLotId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.HasKey("ParkingLotId");

                    b.ToTable("ParkingLots");
                });

            modelBuilder.Entity("Server.Models.ParkingSpot", b =>
                {
                    b.Property<int>("SpotNumber")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IsFree");

                    b.Property<int>("ParkingLotId");

                    b.HasKey("SpotNumber");

                    b.HasIndex("ParkingLotId");

                    b.ToTable("ParkingSpots");
                });

            modelBuilder.Entity("Server.Models.Request", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CarVIN");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("ParkingSpotSpotNumber");

                    b.Property<int>("Status");

                    b.HasKey("RequestId");

                    b.HasIndex("CarVIN");

                    b.HasIndex("ParkingSpotSpotNumber");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("Server.Models.RequestParkingLot", b =>
                {
                    b.Property<int>("ParkingLotId");

                    b.Property<int>("RequestId");

                    b.HasKey("ParkingLotId", "RequestId");

                    b.HasIndex("RequestId");

                    b.ToTable("RequestParkingLot");
                });

            modelBuilder.Entity("Server.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<int>("IsAdmin");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Server.Models.Car", b =>
                {
                    b.HasOne("Server.Models.User", "User")
                        .WithMany("Cars")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Server.Models.ParkingSpot", b =>
                {
                    b.HasOne("Server.Models.ParkingLot", "ParkingLot")
                        .WithMany("ParkingSpots")
                        .HasForeignKey("ParkingLotId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Server.Models.Request", b =>
                {
                    b.HasOne("Server.Models.Car", "Car")
                        .WithMany("Requests")
                        .HasForeignKey("CarVIN")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Server.Models.ParkingSpot", "ParkingSpot")
                        .WithMany("Requests")
                        .HasForeignKey("ParkingSpotSpotNumber");
                });

            modelBuilder.Entity("Server.Models.RequestParkingLot", b =>
                {
                    b.HasOne("Server.Models.ParkingLot", "ParkingLot")
                        .WithMany("Requests")
                        .HasForeignKey("ParkingLotId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Server.Models.Request", "Request")
                        .WithMany("ParkingLots")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
