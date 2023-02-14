﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SHPTH.Data;

#nullable disable

namespace SHPTH.Migrations
{
    [DbContext(typeof(SHPTHContext))]
    [Migration("20230121184327_NEWERA")]
    partial class NEWERA
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SHPTH.Models.CloSepTest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("IsChecked")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CloSepTest");
                });

            modelBuilder.Entity("SHPTH.Models.Cloth", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClothSeparID")
                        .HasColumnType("int");

                    b.Property<int>("GenSep")
                        .HasColumnType("int");

                    b.Property<string>("IMGURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("SizeSeparationID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClothSeparID");

                    b.HasIndex("SizeSeparationID");

                    b.ToTable("Cloth");
                });

            modelBuilder.Entity("SHPTH.Models.Order.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SHPTH.Models.Order.OrderItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("ClothId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderItemID")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("ClothId");

                    b.HasIndex("OrderId");

                    b.HasIndex("OrderItemID");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("SHPTH.Models.Order.ShoppingCartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("ClothId")
                        .HasColumnType("int");

                    b.Property<string>("ShoppingCartId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClothId");

                    b.ToTable("ShoppingCartItems");
                });

            modelBuilder.Entity("SHPTH.Models.SizeSepTest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("IsChecked")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("SizeSepTest");
                });

            modelBuilder.Entity("SHPTH.Models.Cloth", b =>
                {
                    b.HasOne("SHPTH.Models.CloSepTest", "ClothSepar")
                        .WithMany()
                        .HasForeignKey("ClothSeparID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SHPTH.Models.SizeSepTest", "SizeSeparation")
                        .WithMany()
                        .HasForeignKey("SizeSeparationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClothSepar");

                    b.Navigation("SizeSeparation");
                });

            modelBuilder.Entity("SHPTH.Models.Order.OrderItem", b =>
                {
                    b.HasOne("SHPTH.Models.Cloth", "Cloths")
                        .WithMany()
                        .HasForeignKey("ClothId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SHPTH.Models.Order.Order", "Orders")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SHPTH.Models.Order.OrderItem", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderItemID");

                    b.Navigation("Cloths");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("SHPTH.Models.Order.ShoppingCartItem", b =>
                {
                    b.HasOne("SHPTH.Models.Cloth", "Cloth")
                        .WithMany()
                        .HasForeignKey("ClothId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cloth");
                });

            modelBuilder.Entity("SHPTH.Models.Order.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("SHPTH.Models.Order.OrderItem", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
