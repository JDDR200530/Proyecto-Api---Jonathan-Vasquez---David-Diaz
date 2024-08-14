﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proyecto_Poo.Database.Contex;

#nullable disable

namespace Proyecto_Poo.Migrations
{
    [DbContext(typeof(PackageServiceDbContext))]
    [Migration("20240810175724_ColumnCustomers")]
    partial class ColumnCustomers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Proyecto_Poo.Database.Entity.CustomerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("customer_id");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("customer_address");

                    b.Property<int>("Identity")
                        .HasColumnType("int")
                        .HasColumnName("customer_identity");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("customer_name");

                    b.HasKey("Id");

                    b.ToTable("customers", "dbo");
                });

            modelBuilder.Entity("Proyecto_Poo.Database.Entity.OrderEntity", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("order_id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)")
                        .HasColumnName("adress");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("order_date");

                    b.Property<string>("ReciverName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("reciver_name");

                    b.Property<string>("SenderName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("sender_name");

                    b.HasKey("OrderId");

                    b.ToTable("orders", "dbo");
                });

            modelBuilder.Entity("Proyecto_Poo.Database.Entity.OrderPackagesEntity", b =>
                {
                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("order_id");

                    b.Property<Guid>("PackageId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("package_id");

                    b.HasKey("OrderId");

                    b.HasIndex("PackageId");

                    b.ToTable("order_packages", "dbo");
                });

            modelBuilder.Entity("Proyecto_Poo.Database.Entity.PackageEntity", b =>
                {
                    b.Property<Guid>("PackageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("package_id");

                    b.Property<double>("PackageWeight")
                        .HasColumnType("float")
                        .HasColumnName("package_weight");

                    b.HasKey("PackageId");

                    b.ToTable("packages", "dbo");
                });

            modelBuilder.Entity("Proyecto_Poo.Database.Entity.PaymentEntity", b =>
                {
                    b.Property<Guid>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("payment_id");

                    b.Property<double>("Amount")
                        .HasMaxLength(250)
                        .HasColumnType("float")
                        .HasColumnName("amount");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("order_id");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("payment_date");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("payment_method");

                    b.HasKey("PaymentId");

                    b.HasIndex("OrderId");

                    b.ToTable("payments", "dbo");
                });

            modelBuilder.Entity("Proyecto_Poo.Database.Entity.ShipmentEntity", b =>
                {
                    b.Property<Guid>("ShipmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("shipment_id");

                    b.Property<bool>("IsShipped")
                        .HasColumnType("bit")
                        .HasColumnName("shipped");

                    b.Property<Guid>("PaymentId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("payment_id");

                    b.Property<Guid>("TruckId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("truck_available");

                    b.HasKey("ShipmentId");

                    b.HasIndex("PaymentId");

                    b.HasIndex("TruckId");

                    b.ToTable("shipments", "dbo");
                });

            modelBuilder.Entity("Proyecto_Poo.Database.Entity.TruckEntity", b =>
                {
                    b.Property<Guid>("TruckId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("truck_id");

                    b.Property<bool>("TruckAvailable")
                        .HasColumnType("bit")
                        .HasColumnName("truck_available");

                    b.Property<double>("TruckCapacity")
                        .HasColumnType("float")
                        .HasColumnName("truck_capacity");

                    b.HasKey("TruckId");

                    b.ToTable("trucks", "dbo");
                });

            modelBuilder.Entity("Proyecto_Poo.Database.Entity.OrderPackagesEntity", b =>
                {
                    b.HasOne("Proyecto_Poo.Database.Entity.OrderEntity", "Order")
                        .WithMany("Orders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto_Poo.Database.Entity.PackageEntity", "Package")
                        .WithMany("Packages")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Package");
                });

            modelBuilder.Entity("Proyecto_Poo.Database.Entity.PaymentEntity", b =>
                {
                    b.HasOne("Proyecto_Poo.Database.Entity.OrderEntity", "Order")
                        .WithMany("Payment")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Proyecto_Poo.Database.Entity.ShipmentEntity", b =>
                {
                    b.HasOne("Proyecto_Poo.Database.Entity.PaymentEntity", "Pay")
                        .WithMany("Pay")
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto_Poo.Database.Entity.TruckEntity", "Truck")
                        .WithMany("Truck")
                        .HasForeignKey("TruckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pay");

                    b.Navigation("Truck");
                });

            modelBuilder.Entity("Proyecto_Poo.Database.Entity.OrderEntity", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("Proyecto_Poo.Database.Entity.PackageEntity", b =>
                {
                    b.Navigation("Packages");
                });

            modelBuilder.Entity("Proyecto_Poo.Database.Entity.PaymentEntity", b =>
                {
                    b.Navigation("Pay");
                });

            modelBuilder.Entity("Proyecto_Poo.Database.Entity.TruckEntity", b =>
                {
                    b.Navigation("Truck");
                });
#pragma warning restore 612, 618
        }
    }
}
