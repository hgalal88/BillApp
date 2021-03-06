﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Modules.Bills.Infrastructure;

namespace BillAppDDD.Modules.Bills.Infrastructure.Migrations
{
    [DbContext(typeof(BillContext))]
    [Migration("20190919165128_LatestProduct")]
    partial class LatestProduct
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BillAppDDD.Modules.Bills.Domain.Bills.Bill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime>("Date");

                    b.Property<Guid?>("StoreId");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("BillAppDDD.Modules.Bills.Domain.Bills.Purchase", b =>
                {
                    b.Property<Guid>("BillId");

                    b.Property<Guid>("ProductId");

                    b.Property<float>("Amount");

                    b.Property<float>("Cost");

                    b.Property<DateTime>("Date");

                    b.Property<Guid>("Id");

                    b.HasKey("BillId", "ProductId");

                    b.HasAlternateKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Purchase");
                });

            modelBuilder.Entity("BillAppDDD.Modules.Bills.Domain.Products.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CategoryId");

                    b.Property<Guid?>("LastVersionId");

                    b.Property<bool>("LatestVersion");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("LastVersionId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("BillAppDDD.Modules.Bills.Domain.Products.ProductCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<Guid?>("ProductCategoryId");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("BillAppDDD.Modules.Bills.Domain.Stores.Store", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LogoImagePath");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("BillAppDDD.Modules.Bills.Domain.Bills.Bill", b =>
                {
                    b.HasOne("BillAppDDD.Modules.Bills.Domain.Stores.Store", "Store")
                        .WithMany("Bills")
                        .HasForeignKey("StoreId");
                });

            modelBuilder.Entity("BillAppDDD.Modules.Bills.Domain.Bills.Purchase", b =>
                {
                    b.HasOne("BillAppDDD.Modules.Bills.Domain.Bills.Bill", "Bill")
                        .WithMany("Purchases")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BillAppDDD.Modules.Bills.Domain.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BillAppDDD.Modules.Bills.Domain.Products.Product", b =>
                {
                    b.HasOne("BillAppDDD.Modules.Bills.Domain.Products.ProductCategory", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.HasOne("BillAppDDD.Modules.Bills.Domain.Products.Product", "LastVersion")
                        .WithMany()
                        .HasForeignKey("LastVersionId");

                    b.OwnsOne("BillAppDDD.Modules.Bills.Domain.Products.Price", "Price", b1 =>
                        {
                            b1.Property<Guid>("ProductId");

                            b1.Property<float>("Value");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.HasOne("BillAppDDD.Modules.Bills.Domain.Products.Product")
                                .WithOne("Price")
                                .HasForeignKey("BillAppDDD.Modules.Bills.Domain.Products.Price", "ProductId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("BillAppDDD.Modules.Bills.Domain.Products.ProductBarcode", "Barcode", b1 =>
                        {
                            b1.Property<Guid>("ProductId");

                            b1.Property<string>("Value");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.HasOne("BillAppDDD.Modules.Bills.Domain.Products.Product")
                                .WithOne("Barcode")
                                .HasForeignKey("BillAppDDD.Modules.Bills.Domain.Products.ProductBarcode", "ProductId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("BillAppDDD.Modules.Bills.Domain.Products.ProductCategory", b =>
                {
                    b.HasOne("BillAppDDD.Modules.Bills.Domain.Products.ProductCategory")
                        .WithMany("Subcategories")
                        .HasForeignKey("ProductCategoryId");
                });
#pragma warning restore 612, 618
        }
    }
}
