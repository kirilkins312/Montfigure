﻿// <auto-generated />
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
    [Migration("20221218130938_FirstNormMigr")]
    partial class FirstNormMigr
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SHPTH.Models.Cloth", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CloSep")
                        .HasColumnType("int");

                    b.Property<int>("ColSep")
                        .HasColumnType("int");

                    b.Property<int>("GenSep")
                        .HasColumnType("int");

                    b.Property<int>("MatSep")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("SizeSep")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cloth");
                });
#pragma warning restore 612, 618
        }
    }
}
