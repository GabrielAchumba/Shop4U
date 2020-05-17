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
#include "CalculateDeckVariables.h"
#include "Integration.h"
#include "FractionalFlow.h"

using namespace std;
using namespace std::placeholders;;

CalculateDeckVariables::CalculateDeckVariables()
{

}

CalculateDeckVariables::~CalculateDeckVariables()
{

}

void CalculateDeckVariables::GetDeckVariables(vector<vector<InputDeckStruct>>& Faclities,
	vector<Date>& dates, vector<int>& daysList, int& scenario)
{

	double MM = 1000000.0;

	int  j = -1, k = -1;

	for (auto Facility : Faclities)
	{
		vector<vector<ForecastResult>> resultsPerFacility;

		k++; j = -1;

		for (auto deck : Facility)
		{
			j++;

			vector<ForecastResult> resultsPerWell;

			for (int i = 0; i < dates.size(); i++)
			{
				ForecastResult result;
				result.InitailizeData();

				if (dateCreation.EqualTo(dates[i], deck.Date_1P_1C)) // Assign Initial Values
				{
					if (deck.Hydrocarbon_Stream == "oil")
					{
						result.Cum_Oil_Prod = deck.Np;
						result.Cum_Gas_Prod = result.Cum_Oil_Prod * deck.Init_GOR_CGR;
						result.Cum_Water_Prod = result.Cum_Oil_Prod * deck.Init_BSW_WGR / (1 - deck.Init_BSW_WGR);
						result.URo = deck.URo_1P_1C;
						result.URg = deck.URg_1P_1C;
					}
					else
					{
						result.Cum_Gas_Prod = deck.Gp;
						result.Cum_Oil_Prod = result.Cum_Gas_Prod * deck.Init_GOR_CGR / MM;
						result.Cum_Water_Prod = result.Cum_Gas_Prod * deck.Init_BSW_WGR / MM;
						result.URo = deck.URo_1P_1C;
						result.URg = deck.URg_1P_1C;
					}

					if (i > 0)
						resultsPerWell[i - 1] = result;
				}

				
				resultsPerWell.push_back(result);
				

			}

			resultsPerFacility.push_back(resultsPerWell);
		}

		results.push_back(resultsPerFacility);
	}

	int facilityCounter = -1;
	for (auto Facility : Faclities)
	{
		facilityCounter++;
		GetDeckVariables(Facility, dates, daysList, scenario, facilityCounter);
	}
}

void CalculateDeckVariables::GetDeckVariables(vector<InputDeckStruct> facility, vector<Date>& dates, vector<int>& daysList, int& scenario, int& facilityCounter)
{
	double MM = 1000000.0;

	for (int i = 1; i < dates.size(); i++)
	{
		DeltaT = static_cast<double>(daysList[i] - daysList[i - 1]);

		int j = -1;
		for (auto deck : facility)
		{
			j++;
			ForecastResult forecastResult;
			ForecastResult forecastResult_old;

			forecastResult_old = results[facilityCounter][j][i-1];
			forecastResult = results[facilityCounter][j][i - 1];

			if (dateCreation.IsMinimumDate(deck.Date_1P_1C, dates[i])  || dateCreation.EqualTo(deck.Date_1P_1C, dates[i])) // Start Forecast for the well
			{
				forecastResult.ModuleName = deck.Module;
				forecastResult.HyrocarbonStream = deck.Hydrocarbon_Stream;
				forecastResult.Day = dates[i].day;
				forecastResult.Month = dates[i].month;
				forecastResult.Year = dates[i].year;
				forecastResult.CutBack = 1.0;




				GetActiveRate(scenario, deck, forecastResult, forecastResult_old);
				GetVariables(scenario, deck, forecastResult, forecastResult_old);

				if (deck.Hydrocarbon_Stream == "oil")
				{
					if (forecastResult.URo < 0)
					{
						continue;
					}
				}
				else
				{
					if (forecastResult.URg < 0)
					{
						continue;
					}
				}

				results[facilityCounter][j][i] = forecastResult;
			}

			//optimize(ref scenario, deck);

		}
	}

}

void CalculateDeckVariables::GetActiveRate(int& scenario, InputDeckStruct& deck, ForecastResult& forecastResult, ForecastResult& forecastResult_old)
{
	int method = 1;
	double cumprod = 0, MM = 1000000.0;

	if (deck.Hydrocarbon_Stream == "oil")
	{
		

		cumprod = (forecastResult_old.Cum_Oil_Prod - deck.Np) * MM;

		switch (scenario)
		{
		case 1:
			forecastResult.Oil_rate = DCA.Get_DCA(deck.Init_Oil_Gas_Rate_1P_1C,
				deck.Rate_of_Change_Rate_1P_1C, cumprod, method);

			break;

		case 2:
			forecastResult.Oil_rate = DCA.Get_DCA(deck.Init_Oil_Gas_Rate_2P_2C,
				deck.Rate_of_Change_Rate_2P_2C, cumprod, method);

			break;

		case 3:
			forecastResult.Oil_rate = DCA.Get_DCA(deck.Init_Oil_Gas_Rate_3P_3C,
				deck.Rate_of_Change_Rate_3P_3C, cumprod, method);
			break;
		}
	}
	else
	{
		cumprod = (forecastResult_old.Cum_Gas_Prod - deck.Gp) * MM;

		switch (scenario)
		{
		case 1:
			forecastResult.Gas_Rate = DCA.Get_DCA(deck.Init_Oil_Gas_Rate_1P_1C,
				deck.Rate_of_Change_Rate_1P_1C, cumprod, method);

			break;

		case 2:
			forecastResult.Gas_Rate = DCA.Get_DCA(deck.Init_Oil_Gas_Rate_2P_2C,
				deck.Rate_of_Change_Rate_2P_2C, cumprod, method);

			break;

		case 3:
			forecastResult.Gas_Rate = DCA.Get_DCA(deck.Init_Oil_Gas_Rate_3P_3C,
				deck.Rate_of_Change_Rate_3P_3C, cumprod, method);
			break;
		}
	}



}

void CalculateDeckVariables::GetVariables(int& scenario, InputDeckStruct& deck, ForecastResult& forecastResult, ForecastResult& forecastResult_old)
{
	GetActiveCumProd(scenario, deck, forecastResult, forecastResult_old);

	GetGasFractionalFlow(scenario, deck, forecastResult);

	GetWaterFractionalFlow(scenario, deck, forecastResult);

	GetRates(scenario, deck, forecastResult);

	GetCumProds(scenario, deck, forecastResult, forecastResult_old);
}



double CalculateDeckVariables::fun(double ProductionDays)
{
	double rate = DCA.Get_DCA_Exponential2(initial_rate, rate_of_change, ProductionDays);
	return rate;
}

double CalculateDeckVariables::fun2(double ProductionDays)
{
	double rate = DCA.Get_DCA_Exponential2(initial_rate, rate_of_change, ProductionDays);
	return rate;
}

double CalculateDeckVariables::TraplRule(pFUNC fun, double lower, double upper, int subInterval)
{
	int i;
	double k;

	/* Finding step size */
	int stepSize = (upper - lower) / subInterval;

	/* Finding Integration Value */
	double integration = this->fun(lower) + this->fun(upper);

	for (i = 1; i <= subInterval - 1; i++)
	{
		k = lower + i * stepSize;
		integration = integration + 2 * (this->fun(k));
	}

	integration = integration * stepSize / 2;

	return integration;
}

void CalculateDeckVariables::GetActiveCumProd(int& scenario, InputDeckStruct& deck, ForecastResult& forecastResult, ForecastResult& forecastResult_old)
{
	// &DCA.Get_DCA2;



	int interval = 10;
	CalculateDeckVariables obj;
	double lowerbound = 0, MM = 1000000.0;
	double upperbound = DeltaT;

	if (deck.Hydrocarbon_Stream == "oil")
	{
		initial_rate = forecastResult.Oil_rate;
		rate_of_change = deck.Rate_of_Change_Rate_1P_1C;

		obj.initial_rate = initial_rate;
		obj.rate_of_change = rate_of_change;
		//forecastResult.Cum_Oil_Prod = TraplRule(&CalculateDeckVariables::fun, 0, DeltaT, interval);

		auto fp = bind(&CalculateDeckVariables::fun2, obj, std::placeholders::_1);

		forecastResult.Cum_Oil_Prod = forecastResult_old.Cum_Oil_Prod + integration.trapzd(fp, lowerbound, upperbound, interval) / MM;

		
	}
	else
	{
		initial_rate = forecastResult.Gas_Rate;
		rate_of_change = deck.Rate_of_Change_Rate_1P_1C;

		obj.initial_rate = initial_rate;
		obj.rate_of_change = rate_of_change;

		double x = 3.0;

		auto fp = bind(&CalculateDeckVariables::fun2, obj, std::placeholders::_1);

		//forecastResult.Cum_Gas_Prod = TraplRule(&CalculateDeckVariables::fun, 0, DeltaT, interval);
		forecastResult.Cum_Gas_Prod = forecastResult_old.Cum_Gas_Prod + integration.trapzd(fp, lowerbound, upperbound, interval) / MM;

	}
}


void CalculateDeckVariables::GetGasFractionalFlow(int& scenario, InputDeckStruct& deck, ForecastResult& forecastResult)
{
	double MM = 1000000.0, x1 = 0, x2 = 0;

	if (deck.Hydrocarbon_Stream == "oil")
	{
		x1 = deck.Np * MM;
		x2 = forecastResult.Cum_Oil_Prod * MM;

		switch (scenario)
		{
		case 1:
			forecastResult.GOR = fractionalFlow.Get_Fractional_Flow(deck.Rate_Of_Rate_GOR_CGR_1P1C, x1,
				x2, deck.Init_GOR_CGR);
			break;

		case 2:
			forecastResult.GOR = fractionalFlow.Get_Fractional_Flow(deck.Rate_Of_Rate_GOR_CGR_2P2C, x1,
				x2, deck.Init_GOR_CGR);
			break;

		case 3:
			forecastResult.GOR = fractionalFlow.Get_Fractional_Flow(deck.Rate_Of_Rate_GOR_CGR_3P3C, x1,
				x2, deck.Init_GOR_CGR);
			break;
		}
	}
	else
	{
		x1 = deck.Gp * MM;
		x2 = forecastResult.Cum_Gas_Prod * MM;

		switch (scenario)
		{
		case 1:
			forecastResult.CGR = fractionalFlow.Get_Fractional_Flow(deck.Rate_Of_Rate_GOR_CGR_1P1C, x1,
				x2, deck.Init_GOR_CGR);
			break;

		case 2:
			forecastResult.CGR = fractionalFlow.Get_Fractional_Flow(deck.Rate_Of_Rate_GOR_CGR_2P2C, x1,
				x2, deck.Init_GOR_CGR);
			break;

		case 3:
			forecastResult.CGR = fractionalFlow.Get_Fractional_Flow(deck.Rate_Of_Rate_GOR_CGR_3P3C, x1,
				x2, deck.Init_GOR_CGR);
			break;
		}
	}

}

void CalculateDeckVariables::GetWaterFractionalFlow(int& scenario, InputDeckStruct& deck, ForecastResult& forecastResult)
{

	double MM = 1000000.0, x1 = 0, x2 = 0;

	if (deck.Hydrocarbon_Stream == "oil")
	{
		x1 = deck.Np * MM;
		x2 = forecastResult.Cum_Oil_Prod * MM;

		switch (scenario)
		{
		case 1:
			forecastResult.BSW = fractionalFlow.Get_Fractional_Flow(deck.Rate_Of_Rate_BSW_WGR_1P1C, x1,
				x2, deck.Init_BSW_WGR);
			break;

		case 2:
			forecastResult.BSW = fractionalFlow.Get_Fractional_Flow(deck.Rate_Of_Rate_BSW_WGR_2P2C, x1,
				x2, deck.Init_BSW_WGR);
			break;

		case 3:
			forecastResult.BSW = fractionalFlow.Get_Fractional_Flow(deck.Rate_Of_Rate_BSW_WGR_3P3C, x1,
				x2, deck.Init_BSW_WGR);
			break;
		}
	}
	else
	{
		x1 = deck.Gp * MM;
		x2 = forecastResult.Cum_Gas_Prod * MM;

		switch (scenario)
		{
		case 1:
			forecastResult.WGR = fractionalFlow.Get_Fractional_Flow(deck.Rate_Of_Rate_BSW_WGR_1P1C, x1,
				x2, deck.Init_BSW_WGR);
			break;

		case 2:
			forecastResult.WGR = fractionalFlow.Get_Fractional_Flow(deck.Rate_Of_Rate_BSW_WGR_2P2C, x1,
				x2, deck.Init_BSW_WGR);
			break;

		case 3:
			forecastResult.WGR = fractionalFlow.Get_Fractional_Flow(deck.Rate_Of_Rate_BSW_WGR_3P3C, x1,
				x2, deck.Init_BSW_WGR);
			break;
		}
	}

}

void CalculateDeckVariables::GetRates(int& scenario, InputDeckStruct& deck, ForecastResult& forecastResult)
{
	double MM = 1000000.0;
	if (deck.Hydrocarbon_Stream == "oil")
	{
		forecastResult.Gas_Rate = forecastResult.Oil_rate * forecastResult.GOR;
		forecastResult.Water_Rate = forecastResult.Oil_rate * forecastResult.BSW /
			(1 - forecastResult.BSW);
	}
	else
	{
		forecastResult.Oil_rate = forecastResult.Gas_Rate * forecastResult.CGR / MM;
		forecastResult.Water_Rate = forecastResult.Gas_Rate * forecastResult.WGR / MM;
	}
}

void CalculateDeckVariables::GetCumProds(int& scenario, InputDeckStruct& deck, ForecastResult& forecastResult, ForecastResult& forecastResult_old)
{
	Method = 1;
	double lowerbound = 0, MM = 1000000.0;
	double upperbound = DeltaT;
	CalculateDeckVariables obj;

	int interval = 10;

	if (deck.Hydrocarbon_Stream == "oil")
	{
		rate_of_change = deck.Rate_of_Change_Rate_1P_1C;

		initial_rate = forecastResult.Gas_Rate;
		obj.initial_rate = initial_rate;
		obj.rate_of_change = rate_of_change;
		auto fp = bind(&CalculateDeckVariables::fun2, obj, std::placeholders::_1);
		forecastResult.Cum_Gas_Prod = forecastResult_old.Cum_Gas_Prod + forecastResult.GOR * forecastResult.Oil_rate / MM;


		initial_rate = forecastResult.Water_Rate;
		obj.initial_rate = initial_rate;
		obj.rate_of_change = rate_of_change;
		forecastResult.Cum_Water_Prod = forecastResult_old.Cum_Water_Prod + forecastResult.BSW * forecastResult.Oil_rate / (1 - forecastResult.BSW) / MM;

		forecastResult.URo = forecastResult_old.URo - forecastResult.Cum_Oil_Prod;
		forecastResult.URg = 0;

	}
	else
	{
		rate_of_change = deck.Rate_of_Change_Rate_1P_1C;

		initial_rate = forecastResult.Oil_rate;
		obj.initial_rate = initial_rate;
		obj.rate_of_change = rate_of_change;
		auto fp = bind(&CalculateDeckVariables::fun2, obj, std::placeholders::_1);
		forecastResult.Cum_Oil_Prod = forecastResult_old.Cum_Oil_Prod + ((forecastResult.CGR / MM) * forecastResult.Gas_Rate / MM);


		initial_rate = forecastResult.Water_Rate;
		obj.initial_rate = initial_rate;
		obj.rate_of_change = rate_of_change;
		forecastResult.Cum_Water_Prod = forecastResult_old.Cum_Water_Prod + ((forecastResult.WGR / MM) * forecastResult.Gas_Rate / MM);

		forecastResult.URo = 0;
		forecastResult.URg = forecastResult_old.URg - forecastResult.Cum_Gas_Prod;
	}


	
}
bool CalculateDeckVariables::IsDirectory(const char* dirName)
{
	DWORD attribs = ::GetFileAttributesA(dirName);
	if (attribs == INVALID_FILE_ATTRIBUTES) {
		return false;
	}
	return true;
}


void CalculateDeckVariables::CreateFiles(string& BasePath, vector<vector<InputDeckStruct>>& Faclities, vector<string>& FaclitiesNames,
	vector<Date>& dates, vector<int>& daysList, int& scenario)
{

	string FolderFullPath = "";
	string FileFullPath = "";
	string newline = "\n";

	int  j = -1, k = -1;

	for (auto Facility : Faclities)
	{

		k++; j = -1;
		FolderFullPath = BasePath + FaclitiesNames[k];

		if (IsDirectory(FolderFullPath.c_str()) == false)
		{
			_mkdir(FolderFullPath.c_str());
		}
	}

	
	k = -1;
	for (auto Facility : Faclities)
	{
		k++;  j = -1;

		FolderFullPath = BasePath + FaclitiesNames[k];

		for (auto deck : Facility)
		{
			j++;

			for (int i = 0; i < dates.size(); i++)
			{

				if (dateCreation.EqualTo(dates[i], deck.Date_1P_1C)) // Assign Initial Values
				{
					FileFullPath = FolderFullPath + "\\" + deck.Module + ".txt";

					ofstream file{ FileFullPath };

					file.close();

					break;
				}

			}
		}
	}


}

void CalculateDeckVariables::PrintResults(string& BasePath, vector<string>& FaclitiesNames, vector<vector<InputDeckStruct>>& Faclities)
{

	string FolderFullPath = "";
	string FileFullPath = "";
	string newline = "\n";
	string tab = "\t";

	double MM = 1000000.0;

	int counterFacility = -1;
	int deckCounter = -1;
	for (auto resultFacility : results)
	{
		counterFacility++;

		FolderFullPath = BasePath + FaclitiesNames[counterFacility];

		deckCounter = -1;

		for (auto resultsWell : resultFacility)
		{
			deckCounter++;

			auto deck = Faclities[counterFacility][deckCounter];

			FileFullPath = FolderFullPath + "\\" + deck.Module + ".txt";

			ofstream myfile(FileFullPath);


			if (myfile.is_open())
			{

				myfile << "Day" 
					<< tab 
					<< "Month" 
					<< tab 
					<< "Year"
					<< tab
					<< "Oil Rate"
					<< tab
					<< "Gas Rate"
					<< tab
					<< "Water Rate"
					<< tab 
					<< "Cum. Oil Produced"
					<< tab
					<< "Cum. Gas Produced"
					<< tab
					<< "Cum. Water Produced" 
					<< tab
					<< "Produced GOR" 
					<< tab 
					<< "Water Cut"
					<< tab
					<< "Condensate Gas Ratio"
					<< tab
					<< "Water Gas Ratio" 
					<< tab
					<< "Cut Back"
					<< tab 
					<< "Hydrocarbon Stream" 
					<< tab
					<< "Ultimate Oil Recovery"
					<< tab
					<< "Ultimate Gas Recovery"
					<< newline;

				int wellresultcounter = -1;

				for (auto resultWell : resultsWell)
				{
					wellresultcounter++;

					if (wellresultcounter > 0)
					{
						myfile << resultWell.Day 
							<< tab 
							<< resultWell.Month 
							<< tab 
							<< resultWell.Year 
							<< tab
							<< resultWell.Oil_rate
							<< tab 
							<< resultWell.Gas_Rate / MM
							<< tab
							<< resultWell.Water_Rate
							<< tab 
							<< resultWell.Cum_Oil_Prod
							<< tab 
							<< resultWell.Cum_Gas_Prod 
							<< tab
							<< resultWell.Cum_Water_Prod
							<< tab
							<< resultWell.GOR 
							<< tab 
							<< resultWell.BSW 
							<< tab 
							<< resultWell.CGR
							<< tab
							<< resultWell.WGR 
							<< tab
							<< resultWell.CutBack 
							<< tab
							<< resultWell.HyrocarbonStream
							<< tab
							<< resultWell.URo
							<< tab
							<< resultWell.URg
							<< newline;


					}

				}
			}



			myfile.close();
		}





	}

	

}


