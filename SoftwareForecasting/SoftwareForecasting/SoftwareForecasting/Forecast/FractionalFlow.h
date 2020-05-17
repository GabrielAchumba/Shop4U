#pragma once

#include <iostream>
#include <fstream>
#include <stdio.h>
#include <string>
#include <vector>
#include <iomanip>
#include <time.h>
#include "Forecast.h"

using namespace std;

class EXT_FORECAST FractionalFlow
{
private:

public:
	FractionalFlow();
	~FractionalFlow();

	double Get_Fractional_Rate_Of_Change_Exponential(double& X_init, double& X_last, double& Y_init, double& Y_last);

	double Get_Fractional_Flow(double& Fractional_Rate_Of_Change, double& X_init, double& X_last, double& Y_init);

};