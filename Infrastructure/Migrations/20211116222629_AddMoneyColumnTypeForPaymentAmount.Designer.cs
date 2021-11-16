﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211116222629_AddMoneyColumnTypeForPaymentAmount")]
    partial class AddMoneyColumnTypeForPaymentAmount
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Asset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("DailyPrice")
                        .HasColumnType("money");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Assets");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Asset");
                });

            modelBuilder.Entity("Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PaymentAmount")
                        .HasColumnType("money");

                    b.Property<string>("PaymentCurrency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReservedFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReservedTo")
                        .HasColumnType("datetime2");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Order");
                });

            modelBuilder.Entity("Domain.Entities.Orders.ReturnOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReturnTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ReturnOrders");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ReturnOrder");
                });

            modelBuilder.Entity("Domain.Entities.Vehicle", b =>
                {
                    b.HasBaseType("Domain.Entities.Asset");

                    b.Property<string>("Colour")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Vehicle");
                });

            modelBuilder.Entity("Domain.Entities.VehicleOrder", b =>
                {
                    b.HasBaseType("Domain.Entities.Order");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

                    b.HasIndex("VehicleId");

                    b.HasDiscriminator().HasValue("VehicleOrder");
                });

            modelBuilder.Entity("Domain.Entities.Orders.VehicleReturnOrder", b =>
                {
                    b.HasBaseType("Domain.Entities.Orders.ReturnOrder");

                    b.Property<bool>("IsDamaged")
                        .HasColumnType("bit");

                    b.Property<bool>("IsGasFilled")
                        .HasColumnType("bit");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.HasIndex("OrderId");

                    b.HasDiscriminator().HasValue("VehicleReturnOrder");
                });

            modelBuilder.Entity("Domain.Entities.Minivan", b =>
                {
                    b.HasBaseType("Domain.Entities.Vehicle");

                    b.Property<string>("MinivanProperty")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Minivan");
                });

            modelBuilder.Entity("Domain.Entities.Sedan", b =>
                {
                    b.HasBaseType("Domain.Entities.Vehicle");

                    b.Property<string>("SedanProperty")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Sedan");
                });

            modelBuilder.Entity("Domain.Entities.Truck", b =>
                {
                    b.HasBaseType("Domain.Entities.Vehicle");

                    b.Property<string>("TruckProperty")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Truck");
                });

            modelBuilder.Entity("Domain.Entities.VehicleOrder", b =>
                {
                    b.HasOne("Domain.Entities.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Domain.Entities.Orders.VehicleReturnOrder", b =>
                {
                    b.HasOne("Domain.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId");

                    b.Navigation("Order");
                });
#pragma warning restore 612, 618
        }
    }
}
