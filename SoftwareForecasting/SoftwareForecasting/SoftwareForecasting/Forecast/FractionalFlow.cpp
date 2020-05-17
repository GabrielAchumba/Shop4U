#include <iostream>
#include <fstream>
#include <stdio.h>
#include <string>
#include <vector>
#include <iomanip>
#include <time.h>
#include <math.h>
#include <cmath>
#include "Forecast.h"
#include "FractionalFlow.h"

using namespace std;

EXT_FORECAST FractionalFlow::FractionalFlow()
{

}

EXT_FORECAST FractionalFlow::~FractionalFlow()
{

}


double FractionalFlow::Get_Fractional_Rate_Of_Change_Exponential(double& X_init, double& X_last, double& Y_init, double& Y_last)
{
    if (Y_init == 0)Y_init = 0.00000001;

    double numerator = (Y_last / Y_init);

    double denominator = X_last - X_init;

    double Fractional_Rate_Of_Change = log(numerator) / denominator;

    return Fractional_Rate_Of_Change;
}

double FractionalFlow::Get_Fractional_Flow(double& Fractional_Rate_Of_Change, double& X_init, double& X_last, double& Y_init)
{
    double Y = Y_init * exp(Fractional_Rate_Of_Change * (X_last - X_init));

    return Y;
}