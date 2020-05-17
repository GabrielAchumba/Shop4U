﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shop4U.Fastfoods.Models;

namespace Shop4U.Fastfoods.Migrations
{
    [DbContext(typeof(FastfoodDbContext))]
    [Migration("20200228145052_seedfastfoods1")]
    partial class seedfastfoods1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Shop4U.Fastfoods.Models.Fastfood", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("BackgrounndPicture")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Base64String")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fastfoods");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d7211094-cf03-4e25-b2fb-0769eb887904"),
                            Description = "",
                            Name = "Chicken Republic"
                        },
                        new
                        {
                            Id = new Guid("8b586308-d72f-4e76-8f77-b56d55b0c453"),
                            Description = "",
                            Name = "Kilimanjaro"
                        },
                        new
                        {
                            Id = new Guid("b38a5743-3bc5-431d-a0d2-aa87e51fc5fb"),
                            Description = "",
                            Name = "Pizzamore"
                        },
                        new
                        {
                            Id = new Guid("ba143144-2e04-4b06-b4bd-468f45b6f031"),
                            Description = "",
                            Name = "Genesis"
                        },
                        new
                        {
                            Id = new Guid("b8503747-bcfa-4e87-a17f-1a4f0d9fb8e4"),
                            Description = "",
                            Name = "Bole King"
                        },
                        new
                        {
                            Id = new Guid("d62be45f-2fe9-45a6-b817-03b1642b173f"),
                            Description = "",
                            Name = "The Promise"
                        },
                        new
                        {
                            Id = new Guid("48115936-30c9-4350-9b1e-4746784d7cfe"),
                            Description = "",
                            Name = "BestBite"
                        },
                        new
                        {
                            Id = new Guid("71355cb2-3c2c-4f50-9282-42b8d3005c6b"),
                            Description = "",
                            Name = "Native Tray"
                        },
                        new
                        {
                            Id = new Guid("68a761aa-e5b9-43b4-b92e-2e2e9dbe7857"),
                            Description = "",
                            Name = "Sweet Tooth"
                        },
                        new
                        {
                            Id = new Guid("379e4605-0048-4868-8174-7ff0bfac9374"),
                            Description = "",
                            Name = "ColdStone"
                        },
                        new
                        {
                            Id = new Guid("cab6d3f8-4c87-4df9-ad53-1ae4e25ead09"),
                            Description = "",
                            Name = "Jevinik"
                        });
                });

            modelBuilder.Entity("Shop4U.Fastfoods.Models.FastfoodCart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("BackgrounndPicture")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Base64String")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CostPrice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<string>("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MarketName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FastfoodCarts");
                });

            modelBuilder.Entity("Shop4U.Fastfoods.Models.FastfoodItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("BackgrounndPicture")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Base64String")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemCartegoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FastfoodItems");
                });

            modelBuilder.Entity("Shop4U.Fastfoods.Models.FastfoodItemPrice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("BackgrounndPicture")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Base64String")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CostPrice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MarketGroup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("MarketId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MarketName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FastfoodItemPrices");
                });
#pragma warning restore 612, 618
        }
    }
}
