using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftwareForecasting.Migrations
{
    public partial class SeedProforecastData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FacilityDecks",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    Primary_Facility = table.Column<string>(nullable: true),
                    Secondary_Facility = table.Column<string>(nullable: true),
                    Liquid_Capacity = table.Column<string>(nullable: true),
                    Gas_Capacity = table.Column<string>(nullable: true),
                    Scheduled_Deferment = table.Column<string>(nullable: true),
                    Unscheduled_Deferment = table.Column<string>(nullable: true),
                    Thirdparty_Deferment = table.Column<string>(nullable: true),
                    Crudeoil_Lossess = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityDecks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "InputDecks",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    Version_Name = table.Column<string>(nullable: true),
                    Asset_Team = table.Column<string>(nullable: true),
                    Field = table.Column<string>(nullable: true),
                    Reservoir = table.Column<string>(nullable: true),
                    Drainage_Point = table.Column<string>(nullable: true),
                    Production_String = table.Column<string>(nullable: true),
                    Module = table.Column<string>(nullable: true),
                    PEEP_Project = table.Column<string>(nullable: true),
                    Activity_Entity = table.Column<string>(nullable: true),
                    Flow_station = table.Column<string>(nullable: true),
                    Hydrocarbon_Stream = table.Column<string>(nullable: true),
                    Resource_Class = table.Column<string>(nullable: true),
                    Change_Category = table.Column<string>(nullable: true),
                    Technique_1P = table.Column<string>(nullable: true),
                    URo_1P_1C = table.Column<double>(nullable: false),
                    URo_Low = table.Column<double>(nullable: false),
                    URo_2P_2C = table.Column<double>(nullable: false),
                    URo_3P_3C = table.Column<double>(nullable: false),
                    Np = table.Column<double>(nullable: false),
                    URg_1P_1C = table.Column<double>(nullable: false),
                    URg_Low = table.Column<double>(nullable: false),
                    URg_2P_2C = table.Column<double>(nullable: false),
                    URg_3P_3C = table.Column<double>(nullable: false),
                    Gp = table.Column<double>(nullable: false),
                    Init_Oil_Gas_Rate_1P_1C = table.Column<double>(nullable: false),
                    Init_Oil_Gas_Rate_Low = table.Column<double>(nullable: false),
                    Init_Oil_Gas_Rate_2P_2C = table.Column<double>(nullable: false),
                    Init_Oil_Gas_Rate_3P_3C = table.Column<double>(nullable: false),
                    Aband_Oil_Gas_Rate_1P_1C = table.Column<double>(nullable: false),
                    Aband_Oil_Gas_Rate_2P_2C = table.Column<double>(nullable: false),
                    Aband_Oil_Gas_Rate_3P_3C = table.Column<double>(nullable: false),
                    Init_BSW_WGR = table.Column<double>(nullable: false),
                    Aband_BSW_WGR_1P_1C = table.Column<double>(nullable: false),
                    Aband_BSW_WGR_2P_2C = table.Column<double>(nullable: false),
                    Aband_BSW_WGR_3P_3C = table.Column<double>(nullable: false),
                    Init_GOR_CGR = table.Column<double>(nullable: false),
                    Aband_GOR_CGR_1P_1C = table.Column<double>(nullable: false),
                    Aband_GOR_CGR_2P_2C = table.Column<double>(nullable: false),
                    Aband_GOR_CGR_3P_3C = table.Column<double>(nullable: false),
                    lift_Gas_Rate = table.Column<double>(nullable: false),
                    Plateau_Oil_Gas = table.Column<double>(nullable: false),
                    In_year_Booking = table.Column<string>(nullable: true),
                    LE_LV = table.Column<string>(nullable: true),
                    PRCS = table.Column<string>(nullable: true),
                    On_stream_Date_1P_1C = table.Column<string>(nullable: true),
                    On_stream_Date_2P_2C = table.Column<string>(nullable: true),
                    On_stream_Date_3P_3C = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    TRANCHE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputDecks", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacilityDecks");

            migrationBuilder.DropTable(
                name: "InputDecks");
        }
    }
}
