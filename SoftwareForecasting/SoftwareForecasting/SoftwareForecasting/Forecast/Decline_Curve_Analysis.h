#pragma once

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

using namespace std;

class EXT_FORECAST Decline_Curve_Analysis
{
private:

public:
	Decline_Curve_Analysis();
	~Decline_Curve_Analysis();

	double Get_DeclineFactor_Exponential(double& Initial_Rate, double& Aband_Rate, double& Init_Cum_Prod, double& UR);

	double Get_DCA_Exponential(double& Initial_Rate, double& Rate_Of_Change, double& Cum_Prod);

	double Get_DCA_Exponential2(double& Initial_Rate, double& Rate_Of_Change, double& ProductionDays);

	double Get_DCA(double& Initial_Rate, double& Rate_Of_Change, double& Cum_Prod, int& Method);

	double Get_DCA2(double& Initial_Rate, double& Rate_Of_Change, double& ProductionDays, int& Method);

};
