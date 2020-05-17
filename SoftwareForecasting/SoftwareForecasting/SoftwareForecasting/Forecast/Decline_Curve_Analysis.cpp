#include <iostream>
#include <fstream>
#include <stdio.h>
#include <string>
#include <vector>
#include <iomanip>
#include <time.h>
#include <functional>
#include <math.h>
#include "Forecast.h"
#include "Decline_Curve_Analysis.h"

using namespace std;

EXT_FORECAST Decline_Curve_Analysis::Decline_Curve_Analysis()
{

}

EXT_FORECAST Decline_Curve_Analysis::~Decline_Curve_Analysis()
{

}

//double Decline_Curve_Analysis::initial_rate = 0;

double Decline_Curve_Analysis::Get_DeclineFactor_Exponential(double& Initial_Rate, double& Aband_Rate, double& Init_Cum_Prod, double& UR)
{

	double DeclineFactor = (Initial_Rate - Aband_Rate) / (UR - Init_Cum_Prod);

	return DeclineFactor;
}

double Decline_Curve_Analysis::Get_DCA_Exponential(double& Initial_Rate, double& Rate_Of_Change, double& Cum_Prod)
{
	double Current_Rate = Initial_Rate - Rate_Of_Change * Cum_Prod;

	return Current_Rate;
}

double Decline_Curve_Analysis::Get_DCA_Exponential2(double& Initial_Rate, double& Rate_Of_Change, double& ProductionDays)
{
    double Current_Rate = Initial_Rate * exp(-1 * Rate_Of_Change * ProductionDays);

    return Current_Rate;
}

double Decline_Curve_Analysis::Get_DCA(double& Initial_Rate, double& Rate_Of_Change, double& Cum_Prod, int& Method)
{
    double rate = 0;

    switch (Method)
    {
    case 1:
        rate = Get_DCA_Exponential(Initial_Rate, Rate_Of_Change, Cum_Prod);
        break;

    case 2:
        break;

    case 3:
        break;
    }
   

    return rate;
}

double Decline_Curve_Analysis::Get_DCA2(double& Initial_Rate, double& Rate_Of_Change, double& ProductionDays, int& Method)
{
    double rate = 0;

    switch (Method)
    {
    case 1:
        rate = Get_DCA_Exponential2(Initial_Rate, Rate_Of_Change, ProductionDays);
        break;

    case 2:
        break;

    case 3:
        break;
    }

    return rate;
}

