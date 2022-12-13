﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proiect_Magazin.Data;

#nullable disable

namespace Proiect_Magazin.Migrations
{
    [DbContext(typeof(Proiect_MagazinContext))]
    [Migration("20221207150002_UsersAgain")]
    partial class UsersAgain
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Proiect_Magazin.Models.Cart", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("ClothID")
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ClothID");

                    b.HasIndex("UserID");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("Proiect_Magazin.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Proiect_Magazin.Models.Cloth", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int?>("CollectionID")
                        .HasColumnType("int");

                    b.Property<int?>("DesignerID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("SizeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("CollectionID");

                    b.HasIndex("DesignerID");

                    b.HasIndex("SizeID");

                    b.ToTable("Cloth");
                });

            modelBuilder.Entity("Proiect_Magazin.Models.ClothMaterial", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("ClothID")
                        .HasColumnType("int");

                    b.Property<int>("MaterialID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ClothID");

                    b.HasIndex("MaterialID");

                    b.ToTable("ClothMaterial");
                });

            modelBuilder.Entity("Proiect_Magazin.Models.Collection", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CollectionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Collection");
                });

            modelBuilder.Entity("Proiect_Magazin.Models.Designer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Designer");
                });

            modelBuilder.Entity("Proiect_Magazin.Models.Material", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("MaterialName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Material");
                });

            modelBuilder.Entity("Proiect_Magazin.Models.Size", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("SizeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Size");
                });

            modelBuilder.Entity("Proiect_Magazin.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PostalCode")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Proiect_Magazin.Models.Cart", b =>
                {
                    b.HasOne("Proiect_Magazin.Models.Cloth", "Cloth")
                        .WithMany()
                        .HasForeignKey("ClothID");

                    b.HasOne("Proiect_Magazin.Models.User", "User")
                        .WithMany("Carts")
                        .HasForeignKey("UserID");

                    b.Navigation("Cloth");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Proiect_Magazin.Models.Cloth", b =>
                {
                    b.HasOne("Proiect_Magazin.Models.Category", "Category")
                        .WithMany("Clothes")
                        .HasForeignKey("CategoryID");

                    b.HasOne("Proiect_Magazin.Models.Collection", "Collection")
                        .WithMany("Clothes")
                        .HasForeignKey("CollectionID");

                    b.HasOne("Proiect_Magazin.Models.Designer", "Designer")
                        .WithMany("Clothes")
                        .HasForeignKey("DesignerID");

                    b.HasOne("Proiect_Magazin.Models.Size", "Size")
                        .WithMany("Clothes")
                        .HasForeignKey("SizeID");

                    b.Navigation("Category");

                    b.Navigation("Collection");

                    b.Navigation("Designer");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("Proiect_Magazin.Models.ClothMaterial", b =>
                {
                    b.HasOne("Proiect_Magazin.Models.Cloth", "Cloth")
                        .WithMany("ClothMaterials")
                        .HasForeignKey("ClothID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proiect_Magazin.Models.Material", "Material")
                        .WithMany("ClothMaterials")
                        .HasForeignKey("MaterialID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cloth");

                    b.Navigation("Material");
                });

            modelBuilder.Entity("Proiect_Magazin.Models.Category", b =>
                {
                    b.Navigation("Clothes");
                });

            modelBuilder.Entity("Proiect_Magazin.Models.Cloth", b =>
                {
                    b.Navigation("ClothMaterials");
                });

            modelBuilder.Entity("Proiect_Magazin.Models.Collection", b =>
                {
                    b.Navigation("Clothes");
                });

            modelBuilder.Entity("Proiect_Magazin.Models.Designer", b =>
                {
                    b.Navigation("Clothes");
                });

            modelBuilder.Entity("Proiect_Magazin.Models.Material", b =>
                {
                    b.Navigation("ClothMaterials");
                });

            modelBuilder.Entity("Proiect_Magazin.Models.Size", b =>
                {
                    b.Navigation("Clothes");
                });

            modelBuilder.Entity("Proiect_Magazin.Models.User", b =>
                {
                    b.Navigation("Carts");
                });
#pragma warning restore 612, 618
        }
    }
}
