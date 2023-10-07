﻿// <auto-generated />
using System;
using GestHotelsDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestHotelsDomain.Migrations
{
    [DbContext(typeof(HotelDbContext))]
    [Migration("20231007112830_DbReorganization5")]
    partial class DbReorganization5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GestHotelsDomain.Entities.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stars")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Hotel");
                });

            modelBuilder.Entity("GestHotelsDomain.Entities.Price", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("PriceListId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasAlternateKey("PriceListId", "Date")
                        .HasName("IX_UniqueKeyConstraint");

                    b.ToTable("Price");
                });

            modelBuilder.Entity("GestHotelsDomain.Entities.PriceList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId")
                        .IsUnique();

                    b.ToTable("PriceList");
                });

            modelBuilder.Entity("GestHotelsDomain.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("TypeId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("GestHotelsDomain.Entities.RoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RoomType");
                });

            modelBuilder.Entity("GestHotelsDomain.Entities.Price", b =>
                {
                    b.HasOne("GestHotelsDomain.Entities.PriceList", null)
                        .WithMany("Prices")
                        .HasForeignKey("PriceListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GestHotelsDomain.Entities.PriceList", b =>
                {
                    b.HasOne("GestHotelsDomain.Entities.Room", null)
                        .WithOne("PriceList")
                        .HasForeignKey("GestHotelsDomain.Entities.PriceList", "RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GestHotelsDomain.Entities.Room", b =>
                {
                    b.HasOne("GestHotelsDomain.Entities.Hotel", null)
                        .WithMany("Rooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestHotelsDomain.Entities.RoomType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("GestHotelsDomain.Entities.Hotel", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("GestHotelsDomain.Entities.PriceList", b =>
                {
                    b.Navigation("Prices");
                });

            modelBuilder.Entity("GestHotelsDomain.Entities.Room", b =>
                {
                    b.Navigation("PriceList")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}