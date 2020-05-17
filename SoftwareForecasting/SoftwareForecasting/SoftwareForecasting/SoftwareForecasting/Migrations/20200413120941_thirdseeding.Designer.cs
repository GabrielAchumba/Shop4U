﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoftwareForecasting.Models;

namespace SoftwareForecasting.Migrations
{
    [DbContext(typeof(ForecastDbContext))]
    [Migration("20200413120941_thirdseeding")]
    partial class thirdseeding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SoftwareForecasting.Models.FacilityDeck", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Crudeoil_Lossess")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gas_Capacity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("InputDeckId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Liquid_Capacity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Primary_Facility")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Scheduled_Deferment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Secondary_Facility")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Thirdparty_Deferment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unscheduled_Deferment")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("FacilityDecks");
                });

            modelBuilder.Entity("SoftwareForecasting.Models.InputDeck", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Aband_BSW_WGR_1P_1C")
                        .HasColumnType("float");

                    b.Property<double>("Aband_BSW_WGR_2P_2C")
                        .HasColumnType("float");

                    b.Property<double>("Aband_BSW_WGR_3P_3C")
                        .HasColumnType("float");

                    b.Property<double>("Aband_GOR_CGR_1P_1C")
                        .HasColumnType("float");

                    b.Property<double>("Aband_GOR_CGR_2P_2C")
                        .HasColumnType("float");

                    b.Property<double>("Aband_GOR_CGR_3P_3C")
                        .HasColumnType("float");

                    b.Property<double>("Aband_Oil_Gas_Rate_1P_1C")
                        .HasColumnType("float");

                    b.Property<double>("Aband_Oil_Gas_Rate_2P_2C")
                        .HasColumnType("float");

                    b.Property<double>("Aband_Oil_Gas_Rate_3P_3C")
                        .HasColumnType("float");

                    b.Property<string>("Activity_Entity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Asset_Team")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Change_Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Drainage_Point")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Field")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Flow_station")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Gp")
                        .HasColumnType("float");

                    b.Property<string>("Hydrocarbon_Stream")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("In_year_Booking")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Init_BSW_WGR")
                        .HasColumnType("float");

                    b.Property<double>("Init_GOR_CGR")
                        .HasColumnType("float");

                    b.Property<double>("Init_Oil_Gas_Rate_1P_1C")
                        .HasColumnType("float");

                    b.Property<double>("Init_Oil_Gas_Rate_2P_2C")
                        .HasColumnType("float");

                    b.Property<double>("Init_Oil_Gas_Rate_3P_3C")
                        .HasColumnType("float");

                    b.Property<double>("Init_Oil_Gas_Rate_Low")
                        .HasColumnType("float");

                    b.Property<Guid>("InputDeckId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LE_LV")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Module")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Np")
                        .HasColumnType("float");

                    b.Property<string>("On_stream_Date_1P_1C")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("On_stream_Date_2P_2C")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("On_stream_Date_3P_3C")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PEEP_Project")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PRCS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Plateau_Oil_Gas")
                        .HasColumnType("float");

                    b.Property<string>("Production_String")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reservoir")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Resource_Class")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TRANCHE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Technique_1P")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("URg_1P_1C")
                        .HasColumnType("float");

                    b.Property<double>("URg_2P_2C")
                        .HasColumnType("float");

                    b.Property<double>("URg_3P_3C")
                        .HasColumnType("float");

                    b.Property<double>("URg_Low")
                        .HasColumnType("float");

                    b.Property<double>("URo_1P_1C")
                        .HasColumnType("float");

                    b.Property<double>("URo_2P_2C")
                        .HasColumnType("float");

                    b.Property<double>("URo_3P_3C")
                        .HasColumnType("float");

                    b.Property<double>("URo_Low")
                        .HasColumnType("float");

                    b.Property<string>("Version_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("lift_Gas_Rate")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.ToTable("InputDecks");
                });

            modelBuilder.Entity("SoftwareForecasting.Models.InputDeckDateStamp", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DateOfCreation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InputDeckName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("InputDeckDateStamp");
                });
#pragma warning restore 612, 618
        }
    }
}
