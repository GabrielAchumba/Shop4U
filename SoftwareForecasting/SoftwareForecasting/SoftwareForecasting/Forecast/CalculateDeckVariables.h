#pragma once


#include <iostream>
#include <fstream>
#include <stdio.h>
#include <string>
#include <vector>
#include <iomanip>
#include <time.h>
#include <functional>
#include <direct.h>
#include <windows.h>
#include "Forecast.h"
#include "Decline_Curve_Analysis.h"
#include "Integration.h"
#include "FractionalFlow.h"
#include "DateCreation.h"

using namespace std;
using namespace std::placeholders;

class EXT_FORECAST CalculateDeckVariables
{
private:
	Decline_Curve_Analysis DCA;
	FractionalFlow fractionalFlow;
	Integration<double> integration;
	DateCreation dateCreation;

public:

	//typedef double func(double x);

	CalculateDeckVariables();

	void GetDeckVariables(vector<vector<InputDeckStruct>>& Faclities, vector<Date>& dates,  vector<int>& daysList, int& scenario);

	void GetDeckVariables(vector<InputDeckStruct> facility, vector<Date>& dates, vector<int>& daysList, int& scenario, int& facilityCounter);

	void GetActiveRate(int& scenario, InputDeckStruct& deck, ForecastResult& forecastResult, ForecastResult& forecastResult_old);

	void GetVariables(int& scenario, InputDeckStruct& deck, ForecastResult& forecastResult, ForecastResult& forecastResult_old);

	void GetActiveCumProd(int& scenario, InputDeckStruct& deck, ForecastResult& forecastResult, ForecastResult& forecastResult_old);

	~CalculateDeckVariables();

	void GetGasFractionalFlow(int& scenario, InputDeckStruct& deck, ForecastResult& forecastResult);

	void GetWaterFractionalFlow(int& scenario, InputDeckStruct& deck, ForecastResult& forecastResult);

	void GetCumProds(int& scenario, InputDeckStruct& deck, ForecastResult& forecastResult, ForecastResult& forecastResult_old);

	void GetRates(int& scenario, InputDeckStruct& deck, ForecastResult& forecastResult);

	void PrintResults(string& BasePath, vector<string>& FaclitiesNames, vector<vector<InputDeckStruct>>& Faclities);

	void CreateFiles(string& BasePath, vector<vector<InputDeckStruct>>& Faclities, vector<string>& FaclitiesNames,
		vector<Date>& dates, vector<int>& daysList, int& scenario);

	bool IsDirectory(const char* dirName);

	double fun(double a);

	double fun2(double a);

	using pFUNC = double(CalculateDeckVariables::*)(double);

	double TraplRule(pFUNC fun, double lowerBound,  double upperBound,  int intervals);

	double DeltaT;

	double initial_rate;

	double rate_of_change;

	int Method;

	vector<vector<vector<ForecastResult>>> results;

};
