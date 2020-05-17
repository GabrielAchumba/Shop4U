#pragma once

#include <iostream>
#include <fstream>
#include <stdio.h>
#include <string>
#include <vector>
#include <time.h>
#include <iomanip>
#include <functional>

using namespace std;

#ifndef EXT_FORECAST

	#ifdef DLL_BUILD
		#define EXT_FORECAST __declspec(dllexport)
	#else
		#pragma comment(lib, "Forecast.lib")
		#define EXT_FORECAST __declspec(dllimport)
	#endif // DLL_BUILD


#endif // !EXT_FORECAST

extern int EXT_FORECAST max_size;


typedef struct _Date
{
    int day, month, year;
}Date;

typedef enum _DeclineMethod
{
    exponential,
    harmonic,
    hyperbolic

}DeclineMethod;

typedef struct _ForecastResult
{
    int Day;
    int Month;
    int Year;
    double Oil_rate;
    double Gas_Rate;
    double Water_Rate;
    double GOR;
    double CGR;
    double BSW;
    double WGR;
    double Cum_Oil_Prod;
    double Cum_Gas_Prod;
    double Cum_Water_Prod;
    string Description;
    double Decision_Variable;
    double Gas_Own_Use;
    double Gas_Demand;
    double Crude_Oil_Lossess;
    string ModuleName;
    string CustomDate;
    string HyrocarbonStream;
    double CutBack;
    double URo;
    double URg;

    void InitailizeData()
        {
        Day = 0;
        Month = 0;
        Year = 0;
        Oil_rate = 0.0;
        Gas_Rate = 0.0;
        Water_Rate = 0.0;
        GOR = 0.0;
        CGR = 0.0;
        BSW = 0.0;
        WGR = 0.0;
        Cum_Oil_Prod = 0.0;
        Cum_Gas_Prod = 0.0;
        Cum_Water_Prod = 0.0;
        Decision_Variable = 0.0;
        Gas_Own_Use = 0.0;
        Gas_Demand = 0.0;
        Crude_Oil_Lossess = 0.0;
        CutBack = 0.0;
        URo = 0.0;
        URg = 0.0;

        }

}ForecastResult;

typedef struct _InputDeckStruct
{
    string Version_Name;
    string Asset_Team;
    string Field;
    string Reservoir;
    string Drainage_Point;
    string Production_String;
    string Module;
    string PEEP_Project;
    string Activity_Entity;
    string Flow_station;
    string Hydrocarbon_Stream;
    string Resource_Class;
    string Change_Category;
    string Technique_1P;
    double URo_1P_1C; //MMSTB
    double URo_Low;   //MMSTB
    double URo_2P_2C; //MMSTB
    double URo_3P_3C; //MMSTB
    double Np;        //MMSTB
    double URg_1P_1C; //BSCF
    double URg_Low;   //BSCF
    double URg_2P_2C; //BSCF
    double URg_3P_3C; //BSCF
    double Gp;        //BSCF
    double Init_Oil_Gas_Rate_1P_1C; //STB/day or MMSCF/day
    double Init_Oil_Gas_Rate_Low;   //STB/day or MMSCF/day
    double Init_Oil_Gas_Rate_2P_2C; //STB/ady or MMSCF/day
    double Init_Oil_Gas_Rate_3P_3C; //STB/day or MMSCF/day
    double Aband_Oil_Gas_Rate_1P_1C; //STB/day or MMSCF/day
    double Aband_Oil_Gas_Rate_2P_2C; //STB/day or MMSCF/day
    double Aband_Oil_Gas_Rate_3P_3C; //STB/day or MMSCF/day
    double Init_BSW_WGR;             //Fraction or STB/MMSCF
    double Aband_BSW_WGR_1P_1C;      //Fracion  or STB/MMSCF
    double Aband_BSW_WGR_2P_2C;      //Fraction or STB/MMSCF
    double Aband_BSW_WGR_3P_3C;      //Fraction or STB/MMSCF
    double Init_GOR_CGR;             //SCF/STB or STB/MMSCF
    double Aband_GOR_CGR_1P_1C;      //SCF/STB or STB/MMSCF
    double Aband_GOR_CGR_2P_2C;      //SCF/STB or STB/MMSCF
    double Aband_GOR_CGR_3P_3C;      //SCF/STB or STB/MMSCF
    double lift_Gas_Rate;
    double Plateau_Oil_Gas;         // 1.0 means one year
    string In_year_Booking;
    string LE_LV;
    string PRCS;
    string On_stream_Date_1P_1C;
    string On_stream_Date_2P_2C;
    string On_stream_Date_3P_3C;
    string Remarks;
    string TRANCHE;

    string Description;

    //Calculated Variables

    double Rate_Of_Rate_GOR_CGR_1P1C;
    double Rate_Of_Rate_GOR_CGR_2P2C;
    double Rate_Of_Rate_GOR_CGR_3P3C;
    double Rate_Of_Rate_BSW_WGR_1P1C;
    double Rate_Of_Rate_BSW_WGR_2P2C;
    double Rate_Of_Rate_BSW_WGR_3P3C;

    double Rate_of_Change_Rate_1P_1C;
    double Rate_of_Change_Rate_2P_2C;
    double Rate_of_Change_Rate_3P_3C;

    Date Date_1P_1C;
    Date Date_2P_2C;
    Date Date_3P_3C;
} InputDeckStruct;



