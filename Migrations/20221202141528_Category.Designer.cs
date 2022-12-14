// <auto-generated />
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
    [Migration("20221202141528_Category")]
    partial class Category
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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

                    b.Property<string>("DesignerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Designer");
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

            modelBuilder.Entity("Proiect_Magazin.Models.Category", b =>
                {
                    b.Navigation("Clothes");
                });

            modelBuilder.Entity("Proiect_Magazin.Models.Collection", b =>
                {
                    b.Navigation("Clothes");
                });

            modelBuilder.Entity("Proiect_Magazin.Models.Designer", b =>
                {
                    b.Navigation("Clothes");
                });

            modelBuilder.Entity("Proiect_Magazin.Models.Size", b =>
                {
                    b.Navigation("Clothes");
                });
#pragma warning restore 612, 618
        }
    }
}
